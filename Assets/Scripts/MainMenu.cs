using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToload = "MainScene";
    public SceneFader sceneFader;
    public void Play() {
        sceneFader.FadeTo(levelToload);
    }

    public void Quit() {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
