using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Player.StateMachine.Conditions
{
    [CreateAssetMenu(fileName = "IsDoneAnimationPlayerSO", menuName = "State Machines/Player/Conditions/Is Done Animation Player")]
    public class IsDoneAnimationPlayerSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsDoneAnimationPlayer();
        }
    }
    
    public class IsDoneAnimationPlayer : Condition
    {
        private PlayerData _playerData;
        public override void Awake(global::StateMachine.Core.StateMachine stateMachine)
        {
            _playerData = stateMachine.GetComponent<PlayerData>();
        }

        protected override bool Statement()
        {
            return _playerData.IsAnimationFinish;
        }
    }
}