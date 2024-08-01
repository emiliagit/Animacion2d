using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectibleCount : MonoBehaviour
{
    public TextMeshProUGUI FoodCounterText;

    private GameObject[] Food;

    [SerializeField] private string nextLevelScene;
    private void Start()
    {
        
    }

    void Update()
    {
        CountCollectible();
    }

    public void CountCollectible()
    {
        Food = GameObject.FindGameObjectsWithTag("Food");
        int FoodCount = Food.Length;
        FoodCounterText.text = "Food left: " + FoodCount;

        if (FoodCount == 0)
        {
            NextLevel2(nextLevelScene);
        }
    }

    private void NextLevel2(string level)
    {
        SceneManager.LoadScene(level);
    }


}
