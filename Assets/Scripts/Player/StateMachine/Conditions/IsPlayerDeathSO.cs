using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsPlayerDeathSO", menuName = "State Machines/Player/Conditions/Is Player Death Condition")]
    public class IsPlayerDeathSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsPlayerDeath();
        }
    }
    public class IsPlayerDeath : Condition
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        protected override bool Statement()
        {
            return _playerData.IsDeath;
        }
    }
}