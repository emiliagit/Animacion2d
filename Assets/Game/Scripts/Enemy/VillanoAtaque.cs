using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillanoAtaque : MonoBehaviour
{
    public float detectionRange = 5.0f; // Rango de detecci�n
    public float attackRange = 2.0f; // Rango de ataque
    public Transform player; // Referencia al jugador
    public int damage = 10; // Cantidad de da�o que se inflige al jugador

    private Animator animator; // Referencia al Animator
    private bool isAttacking = false; // Indica si el enemigo est� atacando

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Calcular la distancia al jugador

        if (distanceToPlayer <= detectionRange) // Si el jugador est� dentro del rango de detecci�n
        {
            if (distanceToPlayer <= attackRange && !isAttacking) // Si el jugador est� dentro del rango de ataque y no est� atacando
            {
                AttackPlayer();
            }
        }
        else
        {
            animator.SetBool("isAttacking", false); // Asegurarse de que la animaci�n de ataque est� desactivada
        }
    }

    void AttackPlayer()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true); // Activar la animaci�n de ataque
    }

    // Este m�todo se llama desde un evento de animaci�n
    //public void ApplyDamage()
    //{
    //    if (Vector3.Distance(transform.position, player.position) <= attackRange) // Verificar que el jugador todav�a est� en el rango de ataque
    //    {
    //        // Aqu� debes tener un script en el jugador que maneje la vida
    //        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    //    }
    //}

    // Este m�todo se llama desde un evento de animaci�n cuando termina el ataque
    public void EndAttack()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", false); // Desactivar la animaci�n de ataque
    }
}
