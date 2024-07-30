using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Enemy : MonoBehaviour
{
    //public Slider healthSlider;

    public float hp;

    public Transform player;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
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

    
}
