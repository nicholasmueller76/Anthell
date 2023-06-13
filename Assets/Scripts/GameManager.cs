using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float cycleDuration = 300;
    private float currentTime = 0;
    private bool isDay = true;
    // Start is called before the first frame update

    [SerializeField] private float enemySpawnDelay = 10;
    private float currentEnemySpawnTime = 0;
    [SerializeField] private Light2D light;
    [SerializeField] private Gradient daygradient;
    [SerializeField] private Gradient nightgradient;


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= cycleDuration)
        {
            isDay = !isDay;
            if (!isDay)
            {

                Debug.Log("Night");
                currentEnemySpawnTime = 0;
                StartCoroutine(ChangeToNight());
                FindObjectOfType<AudioManager>().PlayMusic("UltimateAssault1");
            }
            else
            {
                Debug.Log("Day");
                StartCoroutine(ChangeToDay());
                FindObjectOfType<AudioManager>().PlayMusic("BorderTown");
            }
            currentTime = 0;
        }


        if (!isDay)
        {
            currentEnemySpawnTime += Time.deltaTime;
            if (currentEnemySpawnTime >= enemySpawnDelay)
            {
                //Debug.Log("Spawning enemy");
                SpawnEnemies();
                currentEnemySpawnTime = 0;
            }
        }
    }

    private void SpawnEnemies()
    {
        // Code to spawn enemies
    }

    public void SetEnemySpawnDelay(float delay)
    {
        enemySpawnDelay = delay;
    }

    IEnumerator ChangeToNight()
    {
        float finished = 5.0f;
        float start = 0.0f;
        while (start <= finished)
        {
            yield return new WaitForSeconds(0.1f);
            light.color = nightgradient.Evaluate(start/finished);
            start += 0.1f;
        }
    }

    IEnumerator ChangeToDay()
    {
        float finished = 5.0f;
        float start = 0.0f;
        while (start <= finished)
        {
            yield return new WaitForSeconds(0.1f);
            light.color = daygradient.Evaluate(start/finished);
            start += 0.1f;
        }
    }
}
