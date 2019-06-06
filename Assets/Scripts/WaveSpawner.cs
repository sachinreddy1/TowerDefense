﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;
    private float countDown = 2f;
    private int waveNumber = 0;

    public GameManager gameManager;

    void Update() {

        if (EnemiesAlive > 0) {
            return;
        }

        if (countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave() 
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveNumber];
        EnemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/ wave.rate);
        }
        waveNumber++;
        if (waveNumber == waves.Length) {
            Debug.Log("Level complete.");
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


}
