using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "StopMovementAction", menuName = "State Machines/Player/Actions/Stop Movement Action")]
    public class StopMovementActionSO : StateActionSO
    {
        [SerializeField] private StateAction.SpecificMoment _moment = default;
        public StateAction.SpecificMoment Moment => _moment;

        protected override StateAction CreateAction() => new StopMovementAction();
    }

    public class StopMovementAction : StateAction
    {
        private Rigidbody2D _rb2d;
        private new StopMovementActionSO OriginSO => (StopMovementActionSO)base.OriginSO;
        
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {

            _rb2d = stateMachine.GetComponent<Rigidbody2D>();
        }

        public override void OnEnterState()
        {
            if (OriginSO.Moment == SpecificMoment.OnEnterState)
                StopMovement();
        }

        public override void OnExitState()
        {
            if(OriginSO.Moment == SpecificMoment.OnStateExit)
                StopMovement();;
        }
        
        public override void OnFixedUpdate()
        {
            if(OriginSO.Moment == SpecificMoment.OnUpdate)
                StopMovement();
        }

        private void StopMovement()
        {
            _rb2d.velocity = Vector2.zero;
        }
    }
}