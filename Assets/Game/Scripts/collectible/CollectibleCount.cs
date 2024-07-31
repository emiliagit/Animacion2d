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

    [SerializeField] private string[] scenes;
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
            GoToNextScene();
        }
    }

    private void GoToNextScene()
    {
        currentSceneIndex++;
        if (currentSceneIndex < scenes.Length)
        {
            SceneManager.LoadScene(scenes[currentSceneIndex]);
        }
        else
        {
            // If there are no more scenes, handle end of game (e.g., show game over screen, credits, etc.)
            Debug.Log("End of game!");
        }

    }
}
