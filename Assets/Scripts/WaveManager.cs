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
        [SerializeField] WaveInfo wave;


        public IEnumerator StartWave(int waveNumber)
        {
            Debug.Log("Starting wave " + waveNumber);
            if (waveNumber < waves.Length)
            {
                wave = waves[waveNumber];
            }
            else
            {
                wave = GenerateRandomWave(waveNumber);
            }
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

        public WaveInfo GenerateRandomWave(int waveNumber)
        {
            WaveInfo wave = new WaveInfo();
            wave.enemies = new EnemyDelayPair[0];
            float difficulty = 0.0f;
            float targetDifficulty = TargetWaveDifficulty(waveNumber);
            for (int i = 0; difficulty < targetDifficulty; i++)
            {
                System.Array.Resize(ref wave.enemies, wave.enemies.Length + 1);
                wave.enemies[i] = new EnemyDelayPair();
                wave.enemies[i].enemyType = (EnemyTypes)Random.Range(0, 3);
                wave.enemies[i].delay = Random.Range(0, 25);
                difficulty += EnemyDifficulty(wave.enemies[i]);
            }
            return wave;
        }

        private float TargetWaveDifficulty(int waveNumber)
        {
            return 2 * Mathf.Pow(waveNumber, 1.3f);
        }

        private float EnemyDifficulty(EnemyDelayPair enemy)
        {
            return (0.2f * (30 - enemy.delay) * EnemyDifficultyScale(enemy.enemyType));
        }

        private float EnemyDifficultyScale(EnemyTypes enemyType)
        {
            switch (enemyType)
            {
                case EnemyTypes.Beetle:
                    return 1.0f;
                case EnemyTypes.Mantis:
                    return 1.5f;
                case EnemyTypes.AcidMaggot:
                    return 2.0f;
                default:
                    return 0.0f;
            }
        }

        public int getNumberOfWaves()
        {
            return waves.Length;
        }
    }

}