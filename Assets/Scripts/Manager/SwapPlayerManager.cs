using System.Collections;
using System.Collections.Generic;
using EventSO;
using Input;
using Player;
using UnityEngine;
namespace GameManager
{
    public class SwapPlayerManager : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;
        [SerializeField] private GameObject followObject;
        [SerializeField] private List<MainPlayer> players;
        [SerializeField] private VoidEventSO onSwapPlayerWhenDie;
        [SerializeField] private VoidEventSO onPlayerDie;
        [SerializeField] private VoidEventSO onEndGame;
        
        private int _currentIndex;

        private void OnEnable()
        {
            onPlayerDie.onEventRaised += OnPlayerDie;
            inputReader.SwapPlayerEvent += OnBtnClickSwapPlayer;
        }

        private void OnDisable()
        {
            onPlayerDie.onEventRaised -= OnPlayerDie;
            inputReader.SwapPlayerEvent -= OnBtnClickSwapPlayer;
        }

        private void Start()
        {
            Init();
        }
        
        private void Init()
        {
            _currentIndex = 0;
            players[_currentIndex].Init(transform.position);
            followObject.transform.SetParent(players[_currentIndex].transform);
            
            for (int i = 1; i < players.Count; i++)
            {
                players[i].gameObject.SetActive(false);
            }
        }

        public void OnBtnClickSwapPlayer()
        {
            if (players.Count <= 1)
                return;
            
            SwapPlayer(false);
        }

        private void SwapPlayer(bool swapWhenDie)
        {
            players[_currentIndex].Return();
            var currentPos = GetCurrentPos();
            
            if(swapWhenDie)
                RemovePlayer();
            
            players[GetSwapPlayer()].BattleOut(currentPos);
            followObject.transform.SetParent(players[_currentIndex].transform);
        }
        
        private void OnPlayerDie()
        {
            if (players.Count > 1)
                StartCoroutine(SwapWhenDieCoroutine());
            else
                onEndGame.RaiseEvent();
        }

        IEnumerator SwapWhenDieCoroutine()
        {
            yield return new WaitForSeconds(2f);
            SwapPlayer(true);
            onSwapPlayerWhenDie.RaiseEvent();
        }

        private int GetSwapPlayer()
        {
            _currentIndex++;
            if (_currentIndex >= players.Count)
                _currentIndex = 0;
            return _currentIndex;
        }

        private void RemovePlayer()
        {
            players.RemoveAt(_currentIndex);
        }

        private Vector3 GetCurrentPos()
        {
            return players[_currentIndex].transform.position;
        }
    }
}