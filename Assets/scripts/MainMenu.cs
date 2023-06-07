using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;

    }

    public void Questions() 
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
