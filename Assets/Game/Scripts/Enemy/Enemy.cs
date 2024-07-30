using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class Enemy : MonoBehaviour
{
    //public Slider healthSlider;

    public float hp;

    public Transform player;

    public Animator animator;
    private Rigidbody2D rb;

    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && !isDead)
        {
            Die();
        }
    }

    public void RecibirDanio()
    {
        hp -= 1;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colision con player");
            //collision.gameObject.GetComponent<LifePlayer>().TakeDamage(1);
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die"); // Inicia la animación de muerte

        rb.velocity = new Vector2(0, -5f); // Hace que el enemigo caiga hacia abajo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead && collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero; // Detiene el movimiento al colisionar con el suelo
        }
    }
}
