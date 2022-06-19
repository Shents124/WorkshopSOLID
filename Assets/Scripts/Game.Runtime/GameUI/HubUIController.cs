using EventSO;
using Player;
using TMPro;
using UnityEngine;

namespace GameUI
{
    public class HubUIController : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private TextMeshProUGUI attackValueTxt;
        [SerializeField] private TextMeshProUGUI attackBuffValueTxt;
        [SerializeField] private PlayerDataEventSO onInitPlayer;
        [SerializeField] private PlayerDataEventSO onSwapPlayer;

        [SerializeField] private VoidEventSO onAttackBuffChangeEvent;
        [SerializeField] private VoidEventSO onHealthChange;

        private PlayerData _playerData;

        private void OnEnable()
        {
            onInitPlayer.onRaisedEvent += Init;
            onSwapPlayer.onRaisedEvent += OnSwapPlayer;
            onAttackBuffChangeEvent.onEventRaised += UpdateDataAttack;
            onHealthChange.onEventRaised += UpdateHealth;
        }

        private void OnDisable()
        {
            onInitPlayer.onRaisedEvent -= Init;
            onSwapPlayer.onRaisedEvent -= OnSwapPlayer;
            onAttackBuffChangeEvent.onEventRaised -= UpdateDataAttack;
            onHealthChange.onEventRaised -= UpdateHealth;
        }

        private void Init(PlayerData playerData)
        {
            SetData(playerData);
        }

        private void OnSwapPlayer(PlayerData playerData)
        {
            SetData(playerData);
        }

        private void UpdateHealth()
        {
            var currentHp = _playerData.CurrentHp;
            var maxHp = _playerData.MaxHp;
            healthBar.SetHealth(currentHp, maxHp);
        }

        private void UpdateDataAttack()
        {
            attackValueTxt.text = _playerData.CalculateNormalDame().ToString();
            attackBuffValueTxt.text = _playerData.AttackBuff.ToString();
        }

        private void SetData(PlayerData playerData)
        {
            _playerData = playerData;
            UpdateHealth();
            UpdateDataAttack();
        }
    }
}