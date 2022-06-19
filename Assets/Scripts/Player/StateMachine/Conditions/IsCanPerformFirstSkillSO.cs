using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsCanPerformFirstSkillSO", menuName = "State Machines/Player/Conditions/IsCanPerformFirstSkill")]
    public class IsCanPerformFirstSkillSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsCanPerformFirstSkill();
        }
    }
    
    public class IsCanPerformFirstSkill : Condition
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        protected override bool Statement()
        {
            return _playerData.CurrentTimeCoolDownFirstSkill <= 0;
        }
    }
}