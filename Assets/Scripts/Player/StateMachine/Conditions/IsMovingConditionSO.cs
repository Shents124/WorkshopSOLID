using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsMovingCondition", menuName = "State Machines/Conditions/Is Moving")]
    public class IsMovingConditionSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsMovingCondition();
        }
    }

    public class IsMovingCondition : Condition
    {
        private PlayerInputController _playerInputController;

        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerInputController = stateMachine.GetComponent<PlayerInputController>();
        }

        protected override bool Statement()
        {
            return Mathf.Abs(_playerInputController.HorizontalInput) > 0;
        }
    }
}