using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsPerformFirstSkillCondition", menuName = "State Machines/Conditions/Is Perform First Skill Condition")]
    public class IsPerformFirstSkillSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsPerformFirstSkill();
        }
    }
    
    public class IsPerformFirstSkill: Condition
    {
        private PlayerInputController _playerInputController;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerInputController = stateMachine.GetComponent<PlayerInputController>();
        }

        protected override bool Statement()
        {
            return _playerInputController.PerformSkill_1;
        }
    }
}