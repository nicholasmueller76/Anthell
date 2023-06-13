using System;
using System.Collections;
using UnityEngine;

// Trying Out This Tutorial: https://www.youtube.com/watch?v=0nq1ZFxuEJY
namespace WorldTime 
{
    public static class WorldTimeConstants
    {
        public const int MinsInDay = 1440;
    }


    public class WorldTime : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;

        [SerializeField]
        private float dLength;

        private TimeSpan currTime;
        private float minLength => dLength / WorldTimeConstants.MinsInDay;

        private void Start()
        {
            StartCoroutine(MinutePass());
        }

        private IEnumerator MinutePass()
        {
            currTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, currTime);
            yield return new WaitForSeconds(minLength);
            StartCoroutine(MinutePass());
        }
    }

}
