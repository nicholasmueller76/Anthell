using UnityEngine;

namespace Anthell
{
    [System.Serializable]
    public enum EnemyTypes
    {
        Beetle,
        Mantis,
        AcidMaggot
    }
    [System.Serializable]
    public struct EnemyDelayPair
    {
        public EnemyTypes enemyType;
        public float delay;
    }


    [CreateAssetMenu(fileName = "WaveInfo", menuName = "ScriptableObjects/WaveInfo", order = 0)]
    public class WaveInfo : ScriptableObject
    {
        public EnemyDelayPair[] enemies;
    }
}