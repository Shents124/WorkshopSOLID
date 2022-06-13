using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsPerformSecondSkillCondition", menuName = "State Machines/Conditions/Is Perform Second Skill Condition")]
    public class IsPerformSecondSkillSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsPerformFirstSkill();
        }
    }
    
    public class IsPerformSecondSkill : Condition
    {
        private PlayerInputController _playerInputController;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerInputController = stateMachine.GetComponent<PlayerInputController>();
        }

        protected override bool Statement()
        {
            return _playerInputController.PerformSkill_2;
        }
    }
}