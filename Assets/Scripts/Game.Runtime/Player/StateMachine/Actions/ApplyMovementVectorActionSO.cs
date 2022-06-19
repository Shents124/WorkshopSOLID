using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "ApplyMovementVectorAction", menuName = "State Machines/Player/Actions/ApplyMovementVectorAction")]
    public class ApplyMovementVectorActionSO : StateActionSO<ApplyMovementVectorAction>
    {
        
    }

    public class ApplyMovementVectorAction : StateAction
    {
        private PlayerAction _playerAction;
        private PlayerInputController _input;
        private PlayerData _playerData;
        
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerAction = stateMachine.GetComponent<PlayerAction>();
            _input = stateMachine.GetComponent<PlayerInputController>();
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        
        public override void OnFixedUpdate()
        {
            _playerAction.Move(_input.HorizontalInput, _playerData.Speed);
        }
    }
}