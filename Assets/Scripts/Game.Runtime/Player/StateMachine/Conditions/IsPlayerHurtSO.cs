using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsPlayerHurtSO",
        menuName = "State Machines/Player/Conditions/Is Player Hurt Condition")]
    public class IsPlayerHurtSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsPlayerHurtCondition();
        }
    }

    public class IsPlayerHurtCondition : Condition
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        protected override bool Statement()
        {
            return _playerData.IsHurt;
        }
    }
}