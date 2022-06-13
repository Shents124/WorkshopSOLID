using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "ApplyMovementVectorAction", menuName = "State Machines/Actions/ApplyMovementVectorAction")]
    public class ApplyMovementVectorActionSO : StateActionSO<ApplyMovementVectorAction>
    {
        public float speed = 150f;
    }

    public class ApplyMovementVectorAction : StateAction
    {
        private PlayerController _playerController;
        private PlayerInputController _input;
        private new ApplyMovementVectorActionSO OriginSO => (ApplyMovementVectorActionSO)base.OriginSO;
        
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerController = stateMachine.GetComponent<PlayerController>();
            _input = stateMachine.GetComponent<PlayerInputController>();
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnFixedUpdate()
        {
            _playerController.Move(_input.HorizontalInput, OriginSO.speed);
        }
    }
}