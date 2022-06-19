using System;
using UnityEngine;
using TMPro;
namespace GameUI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentTimeSurvival;
        [SerializeField] private TextMeshProUGUI highestTimeSurvival;

        private const string TIME_FORMAT = "hh':'mm':'ss";
        
        public void ShowGameOver(float currentTime, float highestTime)
        {
            var currentTimeSpan = TimeSpan.FromSeconds(currentTime).ToString(TIME_FORMAT);
            var highestTimeSpan = TimeSpan.FromSeconds(highestTime).ToString(TIME_FORMAT);
            currentTimeSurvival.text = currentTimeSpan;
            highestTimeSurvival.text = highestTimeSpan;
        }
    }
}