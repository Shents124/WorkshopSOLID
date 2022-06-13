using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "StopMovementAction", menuName = "State Machines/Actions/Stop Movement Action")]
    public class StopMovementActionSO : StateActionSO
    {
        [SerializeField] private StateAction.SpecificMoment _moment = default;
        public StateAction.SpecificMoment Moment => _moment;

        protected override StateAction CreateAction() => new StopMovement();
    }

    public class StopMovement : StateAction
    {
        private PlayerController _playerController;
        private new StopMovementActionSO OriginSO => (StopMovementActionSO)base.OriginSO;
        
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {

            _playerController = stateMachine.GetComponent<PlayerController>();
        }

        public override void OnEnterState()
        {
            if(OriginSO.Moment == SpecificMoment.OnEnterState)
                _playerController.StopMovement();
        }

        public override void OnExitState()
        {
            if(OriginSO.Moment == SpecificMoment.OnStateExit)
                _playerController.StopMovement();
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnFixedUpdate()
        {
            if(OriginSO.Moment == SpecificMoment.OnUpdate)
                _playerController.StopMovement();
        }
    }
}