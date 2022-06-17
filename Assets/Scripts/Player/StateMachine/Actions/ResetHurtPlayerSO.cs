using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Actions
{
    [CreateAssetMenu(fileName = "ResetHurtPlayerSO", menuName = "State Machines/Player/Actions/Reset Hurt Player ")]
    public class ResetHurtPlayerSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new ResetHurtPlayer();
        }
    }

    public class ResetHurtPlayer : StateAction
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        public override void OnExitState()
        {
            _playerData.ResetHurt();
        }
    }
}