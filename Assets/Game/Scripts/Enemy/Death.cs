using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    public Animator animator;
    private bool isDead = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //hp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("dead true");
        animator.SetTrigger("Die"); // Inicia la animación de muerte

        rb.velocity = new Vector2(0, -5f);
        Debug.Log("cayedo");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead && collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero; // Detiene el movimiento al colisionar con el suelo
        }
    }
}
