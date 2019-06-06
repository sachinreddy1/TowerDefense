using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public GameObject levelSelection;
    public Button[] levelButtons;

    void Start() {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    public void Play() {
        levelSelection.SetActive(true);
    }   

    public void LoadLevel(string levelName){
        sceneFader.FadeTo(levelName);
    }


    public void Quit() {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
