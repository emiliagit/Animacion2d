using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackHitDelay;
    [SerializeField] private float extraDelayUntilSpriteFlip;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    private Animator animator;
    private float nextTimeToAttack;

    public static bool isAttacking;

    public float hp;

    //[SerializeField] private PlayerStatsScriptableObject playerStats;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToAttack)
            TriggerAttack();
    }

    private void TriggerAttack()
    {
        nextTimeToAttack = Time.time + 1f / attackSpeed;
        animator.SetTrigger("IsAttacking");

        StartCoroutine(AttackAction());
    }

    private IEnumerator AttackAction()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackHitDelay);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.TryGetComponent(out Ataque ataque))
            {
                ataque.RecibirDanio();
            }
            if(enemy.TryGetComponent(out VillanoAtaque villano))
            {
                villano.TakeDamage(20);
            }
            
            
        }
        

        yield return new WaitForSeconds(extraDelayUntilSpriteFlip);

        isAttacking = false;
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
