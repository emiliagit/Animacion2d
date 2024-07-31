using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillanoAtaque : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackHitDelay;
    [SerializeField] private float attackTriggerDistance;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float extraDelayUntilSpriteFlip;
    [SerializeField] private GameObject canvas;
    private Animator animator;
    private float nextTimeToAttack;
    private float distanceToPlayer;

    public int currentHealth;

    private bool isAttacking;
    private Transform playerPosition;
    private HealthBar healthBar;
    private Vector2 toPlayerDirection;

    public Slider slider;

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        playerPosition = FindObjectOfType<PlayerController>().transform;
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;

        //healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Update()
    {
        if (playerPosition == null) return;

        toPlayerDirection = playerPosition.position - transform.position;
        FlipSprite();

        distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);

        if (distanceToPlayer <= attackTriggerDistance && !isAttacking && Time.time >= nextTimeToAttack)
        {
            TriggerAttack();
        }

        slider.value = currentHealth;


    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
        //healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        //else if (!isAttacking)
            //animator.SetTrigger("Hurt");
    }

    private void TriggerAttack()
    {
        isAttacking = true;
        nextTimeToAttack = Time.time + 1f / attackSpeed;

        animator.SetTrigger("Attack");

        StartCoroutine(AttackAction());
    }

    private IEnumerator AttackAction()
    {
        yield return new WaitForSeconds(attackHitDelay);

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Health>().RecibirDanio(2);
        }

        yield return new WaitForSeconds(extraDelayUntilSpriteFlip);

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void FlipSprite()
    {
        if (isAttacking) return;

        if (toPlayerDirection.x < 0f)
        {
            transform.localScale = new(0.5f, 0.5f, 0.5f);
            canvas.transform.localScale = new(0.03f, 0.03f, 0.03f);
        }
        else if (toPlayerDirection.x > 0f)
        {
            transform.localScale = new(-0.5f, 0.5f, 0.5f);
            canvas.transform.localScale = new(-0.03f, 0.03f, 0.03f);
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");

        StopAllCoroutines();
        healthBar.enabled = false;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
