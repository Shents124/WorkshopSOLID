using EventSO;
using Player;
using UnityEngine;

namespace GameUI
{
    public class ControllerUI : MonoBehaviour
    {
        [SerializeField] private UISkillCoolDown skill1;
        [SerializeField] private UISkillCoolDown skill2;
        [SerializeField] private PlayerDataEventSO onInitPlayer;
        [SerializeField] private PlayerDataEventSO onSwapPlayer;

        private void OnEnable()
        {
            onInitPlayer.onRaisedEvent += InitSkill;
            onSwapPlayer.onRaisedEvent += SwapPlayer;
        }

        private void OnDisable()
        {
            onInitPlayer.onRaisedEvent -= InitSkill;
            onSwapPlayer.onRaisedEvent -= SwapPlayer;
        }

        private void InitSkill(PlayerData playerData)
        {
            var coolDownSkill1 = playerData.TimeCoolDownFirstSkill;
            var coolDownSkill2 = playerData.TimeCoolDownSecondSkill;
            skill1.Init(coolDownSkill1);
            skill2.Init(coolDownSkill2);
        }

        private void SwapPlayer(PlayerData playerData)
        {
            var currentCoolDownSkill1 = playerData.CurrentTimeCoolDownFirstSkill;
            var currentCoolDownSkill2 = playerData.CurrentTimeCoolDownSecondSkill;
            skill1.StartCountDown(currentCoolDownSkill1);
            skill2.StartCountDown(currentCoolDownSkill2);
        }
    }
}