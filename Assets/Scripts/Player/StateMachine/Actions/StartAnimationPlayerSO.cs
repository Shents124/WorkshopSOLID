using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "StartAnimationPlayerSO", menuName = "State Machines/Player/Actions/Start Animation Player")]
    public class StartAnimationPlayerSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new StartAnimationPlayer();
        }
    }

    public class StartAnimationPlayer : StateAction
    {
        private PlayerData _playerData;
        
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        public override void OnEnterState()
        {
            _playerData.StartAnimation();
        }
    }
}