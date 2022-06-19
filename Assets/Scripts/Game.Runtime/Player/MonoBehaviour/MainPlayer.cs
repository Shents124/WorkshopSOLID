using EventSO;
using UnityEngine;

namespace Player
{
    public class MainPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerDataEventSO onInitSkill;
        [SerializeField] private PlayerDataEventSO onSwapPlayer;
        private PlayerData _playerData;

        private void Awake()
        {
            _playerData = GetComponent<PlayerData>();
        }

        public void Init(Vector3 position)
        {
            gameObject.SetActive(true);
            onInitSkill.RaiseEvent(_playerData);
            transform.position = position;
        }
        
        public void BattleOut(Vector3 position)
        {
            gameObject.SetActive(true);
            onInitSkill.RaiseEvent(_playerData);
            onSwapPlayer.RaiseEvent(_playerData);
            transform.position = position;
        }
        
        public void Return()
        {
            gameObject.SetActive(false);
        }
    }
}