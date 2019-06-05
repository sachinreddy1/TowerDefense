using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToload = "MainScene";
    public void Play() {
        SceneManager.LoadScene(levelToload);
    }

    public void Quit() {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
