using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded;
    public GameObject gameOverUI;
    public string nextLevel = "Level_02";
    public int levelToUnlock = 2;
    public SceneFader sceneFader;

    void Start () {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    private void EndGame () {
        gameEnded = true;
        Debug.Log("GAME OVER.");
        gameOverUI.SetActive(true);
    }

    public void WinLevel() {
        Debug.Log("Win level.");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
