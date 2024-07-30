using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defensa : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private Transform controladorDefensa;
    [SerializeField] private float radioDefensa;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {


        if (Input.GetMouseButton(1))
        {
            Defending();
            animator.SetBool("Defensa", true);

        }
        else
        {
            animator.SetBool("Defensa", false);
        }
    }

    private void Defending()
    {
        Collider[] objetos = Physics.OverlapSphere(controladorDefensa.position, radioDefensa);

        //foreach (Collider colisionador in objetos)
        //{
        //    if (colisionador.CompareTag("Enemy"))
        //    {
        //        colisionador.transform.GetComponent<EnemyPadre>().RecibirDanio();
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorDefensa.position, radioDefensa);
    }
}
