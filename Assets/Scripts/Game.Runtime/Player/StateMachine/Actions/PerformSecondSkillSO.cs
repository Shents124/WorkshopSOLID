using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "PerformSecondSkillSO", menuName = "State Machines/Player/Actions/PerformSecondSkillSO")]
    public class PerformSecondSkillSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new PerformSecondSkill();
        }
    }

    public class PerformSecondSkill : StateAction
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        public override void OnEnterState()
        {
            _playerData.PerformSecondSkill();
        }
    }
}