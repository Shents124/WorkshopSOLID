using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsCanPerformSecondSkillSO", menuName = "State Machines/Player/Conditions/IsCanPerformSecondSkill")]
    public class IsCanPerformSecondSkillSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsCanPerformSecondSkill();
        }
    }
    
    public class IsCanPerformSecondSkill : Condition
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        protected override bool Statement()
        {
            return _playerData.CurrentTimeCoolDownSecondSkill <= 0;
        }
    }
}
