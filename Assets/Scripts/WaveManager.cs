using System.Collections;
using UnityEngine;

namespace Anthell
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private WaveInfo[] waves;
        [SerializeField] private GameObject beetlePrefab;
        [SerializeField] private GameObject mantisPrefab;
        [SerializeField] private GameObject acidMaggotPrefab;
        [SerializeField] private GameObject spawnPoint;
        // Target
        [SerializeField] private GameObject queenAnt;

        public IEnumerator StartWave(int waveNumber)
        {
            Debug.Log("Starting wave " + waveNumber);
            WaveInfo wave = waves[waveNumber];
            foreach (EnemyDelayPair enemy in wave.enemies)
            {
                GameObject newEnemyGameObject = null;
                Enemy newEnemy = null;
                yield return new WaitForSeconds(enemy.delay);
                switch (enemy.enemyType)
                {
                    case EnemyTypes.Beetle:
                        newEnemyGameObject = GameObject.Instantiate(beetlePrefab, spawnPoint.transform.position, Quaternion.identity);
                        newEnemy = newEnemyGameObject?.GetComponent<Beetle>();
                        break;
                    case EnemyTypes.Mantis:
                        newEnemyGameObject = GameObject.Instantiate(mantisPrefab, spawnPoint.transform.position, Quaternion.identity);
                        newEnemy = newEnemyGameObject?.GetComponent<Mantis>();
                        break;
                    case EnemyTypes.AcidMaggot:
                        newEnemyGameObject = GameObject.Instantiate(acidMaggotPrefab, spawnPoint.transform.position, Quaternion.identity);
                        newEnemy = newEnemyGameObject?.GetComponent<AcidMaggot>();
                        break;
                    default:
                        continue;
                }
                newEnemy?.setQueenAnt(queenAnt);
                newEnemy?.AddTask(new EntityTask(EntityTaskTypes.Attack, queenAnt));
            }
        }

        public int getNumberOfWaves()
        {
            return waves.Length;
        }
    }

}