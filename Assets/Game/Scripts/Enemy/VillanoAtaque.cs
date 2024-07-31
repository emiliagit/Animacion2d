using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillanoAtaque : MonoBehaviour
{
    public float detectionRange = 5.0f; // Rango de detección
    public float attackRange = 2.0f; // Rango de ataque
    public Transform player; // Referencia al jugador
    public int damage = 10; // Cantidad de daño que se inflige al jugador

    private Animator animator; // Referencia al Animator
    private bool isAttacking = false; // Indica si el enemigo está atacando

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Calcular la distancia al jugador

        if (distanceToPlayer <= detectionRange) // Si el jugador está dentro del rango de detección
        {
            if (distanceToPlayer <= attackRange && !isAttacking) // Si el jugador está dentro del rango de ataque y no está atacando
            {
                AttackPlayer();
            }
        }
        else
        {
            animator.SetBool("isAttacking", false); // Asegurarse de que la animación de ataque esté desactivada
        }
    }

    void AttackPlayer()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true); // Activar la animación de ataque
    }

    // Este método se llama desde un evento de animación
    //public void ApplyDamage()
    //{
    //    if (Vector3.Distance(transform.position, player.position) <= attackRange) // Verificar que el jugador todavía esté en el rango de ataque
    //    {
    //        // Aquí debes tener un script en el jugador que maneje la vida
    //        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    //    }
    //}

    // Este método se llama desde un evento de animación cuando termina el ataque
    public void EndAttack()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", false); // Desactivar la animación de ataque
    }
}
