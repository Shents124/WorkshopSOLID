using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Actions
{
    [CreateAssetMenu(fileName = "FollowPlayer", menuName = "State Machines/Enemy/Actions/Follow Player")]
    public class FollowPlayerSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new FollowPlayer();
        }
    }
    
    public class FollowPlayer: StateAction
    {
        private EnemyAIData _enemyAiData;
        private EnemyAIAction _enemyAiAction;
        
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
            _enemyAiAction = stateMachine.GetComponent<EnemyAIAction>();
        }

        public override void OnUpdate()
        {
            if(_enemyAiData.CheckFlip())
                _enemyAiAction.Flip(_enemyAiData.LocalScale);
        }

        public override void OnFixedUpdate()
        {
            _enemyAiAction.Move(_enemyAiData.Speed, _enemyAiData.MoveDirection);
        }
    }
}