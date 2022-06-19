using EventSO;
using GameUI;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private VoidEventSO onEndGame;
        [SerializeField] private TimeCounter timeCounter;
        [SerializeField] private GameOverUI gameOverUi;
        
        private const string KEY = "HighScore";

        private void OnEnable()
        {
            onEndGame.onEventRaised += OnEndGame;
        }

        private void OnDisable()
        {
            onEndGame.onEventRaised -= OnEndGame;
        }

        private void Start()
        {
            gameOverUi.gameObject.SetActive(false);
        }

        private void OnEndGame()
        {
            SaveData();
            gameOverUi.gameObject.SetActive(true);
            gameOverUi.ShowGameOver(timeCounter.GetElapsedTime, GetData());
        }
        
        private void SaveData()
        {
            if(timeCounter.GetElapsedTime > GetData())
                PlayerPrefs.SetFloat(KEY, timeCounter.GetElapsedTime);
        }

        private float GetData()
        {
            return PlayerPrefs.GetFloat(KEY);
        }
    }
}