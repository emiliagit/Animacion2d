using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;


    public float hp;

    

    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
    }

    private void Update()
    {

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }
       
        UpdateHealthUI();

    }

    public void RecibirDanio(float dmg)
    {
        hp -= dmg;
        UpdateHealthUI();
    }

    public void RecibirVida(float vida)
    {
        hp += vida;
    }


    void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;

    }
}
