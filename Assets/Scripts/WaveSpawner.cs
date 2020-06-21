using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float waveInterval = 5.5f;

    private float countDown = 2f;

    private int waveNumber = 1;

    public Transform spawnPoint;

    public Text countDownText;
    private void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = waveInterval;
        }

        countDown -= Time.deltaTime;
        countDownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy();
        }
        waveNumber++;
    }


    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
