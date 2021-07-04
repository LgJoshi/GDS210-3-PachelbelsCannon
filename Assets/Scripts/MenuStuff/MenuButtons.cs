using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void LoadCredits(){
        SceneManager.LoadScene("Credits");
    }
}
