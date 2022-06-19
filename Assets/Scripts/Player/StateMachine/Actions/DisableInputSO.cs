using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "DisableInputSO", menuName = "State Machines/Player/Actions/DisableInput")]
    public class DisableInputSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new DisableInput();
        }
    }

    public class DisableInput : StateAction
    {
        private PlayerInputController _playerInputController;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerInputController = stateMachine.GetComponent<PlayerInputController>();
        }

        public override void OnEnterState()
        {
            _playerInputController.DisableInput();
        }
    }
}