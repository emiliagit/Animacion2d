using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : Enemy
{
    public float radio = 10f; // Radio de detecci�n del jugador
    public float moveSpeed = 0.5f; // Velocidad de movimiento del enemigo


    private bool playerDetectado = false; // Variable para controlar si el jugador ha sido detectado
    private Vector3 playerPosition;

    private Rigidbody2D Rb;

    public Animator Animator;

   
    private bool isDead = false;
  


    private void Start()
    {

        //hp = 2;
        Rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca el transform del jugador
    }

    private void Update()
    {
        MovEnemy();

        if (hp == 0 && !isDead)
        {
            Die();
        }
    }

    private void MovEnemy()
    {
        if (hp > 0)
        {
            if (!playerDetectado)
            {
                // Comprueba si el jugador est� dentro del radio de detecci�n
                if (Vector3.Distance(transform.position, player.position) <= radio)
                {
                    Debug.Log("player detectado");
                    playerDetectado = true; // Marca al jugador como detectado
                    playerPosition = player.position; // Establece la posici�n del jugador como destino
                }
            }
            else
            {
                // Comprueba si el enemigo ha llegado a la posici�n del jugador
                if (Vector3.Distance(transform.position, playerPosition) <= 0.1f) // Puedes ajustar el umbral seg�n sea necesario
                {
                    // Calcula la nueva posici�n del jugador
                    playerPosition = player.position;
                }

                // Calcula la direcci�n hacia la nueva posici�n del jugador
                Vector3 direction = (playerPosition - transform.position).normalized;

                // Mueve al enemigo hacia la posici�n del jugador
                transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("dead true");
        Animator.SetTrigger("Die"); // Inicia la animaci�n de muerte

        Rb.velocity = new Vector2(0, -5f);
        Debug.Log("cayedo");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead && collision.gameObject.CompareTag("Ground"))
        {
            Rb.velocity = Vector2.zero; // Detiene el movimiento al colisionar con el suelo
        }
        if(collision.gameObject.TryGetComponent(out Health player))
        {
            player.RecibirDanio(2);
        }
    }
}
