using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace WorldTime {
    public class WorldTimeDisplay : MonoBehaviour 
    {
        [SerializeField] private WorldTime wT;

        private TMP_Text text;

        private void Awake() 
        {
            text = GetComponent<TMP_Text>();
            wT.WorldTimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            wT.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newT)
        {
            text.SetText(newT.ToString(@"hh\:mm"));
        }
    }
}


