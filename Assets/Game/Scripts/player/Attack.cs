using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Attaque();
            animator.SetBool("IsAttacking", true);

        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void Attaque()
    {
        Collider[] objetos = Physics.OverlapSphere(controladorGolpe.position, radioGolpe);

        foreach (Collider colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent < Enemy>().RecibirDanio();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
