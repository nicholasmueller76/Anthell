using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

namespace WorldTime {
    public class WorldLighting : MonoBehaviour
    {
        private Light2D light;

        [SerializeField] private WorldTime wT;
        [SerializeField] private Gradient gradient;

        private void Awake()
        {
            light = GetComponent<Light2D>();
            wT.WorldTimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            wT.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newT)
        {
            light.color = gradient.Evaluate(DayPercentage(newT));
        }

        private float DayPercentage(TimeSpan time) 
        {
            return (float)time.TotalMinutes % WorldTimeConstants.MinsInDay / WorldTimeConstants.MinsInDay;
        }
    }
}

