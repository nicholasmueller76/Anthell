using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float cycleDuration = 300;
    private float currentTime = 0;
    private bool isDay = true;
    // Start is called before the first frame update

    [SerializeField] private float enemySpawnDelay = 10;
    private float currentEnemySpawnTime = 0;

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
            }
            else
            {
                Debug.Log("Day");
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
}
