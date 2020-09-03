using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ReloadScene()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
    }
    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        

    }
}
