using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

namespace Anthell
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float cycleDuration = 20;
        private float currentTime;
        private bool isDay;
        // Start is called before the first frame update
        [SerializeField] private Light2D gameLight;
        [SerializeField] private Gradient daygradient;
        [SerializeField] private Gradient nightgradient;
        private WaveManager waveManager;
        private int waveNumber = 0;

        private void Awake()
        {
            waveManager = GetComponent<WaveManager>();
            currentTime = 0;
            isDay = true;
            FindObjectOfType<AudioManager>().PlayMusic("BorderTown");
        }

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
                    StartCoroutine(waveManager.StartWave(waveNumber));
                    waveNumber++;
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
        }

        IEnumerator ChangeToNight()
        {
            float finished = 5.0f;
            float start = 0.0f;
            while (start <= finished)
            {
                yield return new WaitForSeconds(0.1f);
                gameLight.color = nightgradient.Evaluate(start / finished);
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
                gameLight.color = daygradient.Evaluate(start / finished);
                start += 0.1f;
            }
        }
    }
}
