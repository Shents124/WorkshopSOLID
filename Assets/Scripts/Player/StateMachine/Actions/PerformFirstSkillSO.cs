using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "PerformFirstSkillSO", menuName = "State Machines/Player/Actions/Perform First Skill ")]
    public class PerformFirstSkillSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new PerformFirstSkill();
        }
    }

    public class PerformFirstSkill : StateAction
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        public override void OnEnterState()
        {
            _playerData.PerformFirstSkill();
        }
    }
}