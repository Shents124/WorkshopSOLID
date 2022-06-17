using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Actions
{
    [CreateAssetMenu(fileName = "StartAnimationEnemySO", menuName = "State Machines/Enemy/Actions/Start Animation")]
    public class StartAnimationEnemySO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new StartAnimationEnemy();
        }
    }
    
    public class StartAnimationEnemy : StateAction
    {
        private EnemyAIData _enemyAiData;
        private EnemyAIAction _enemyAiAction;
        
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
            _enemyAiAction = stateMachine.GetComponent<EnemyAIAction>();
        }

        public override void OnEnterState()
        {
            _enemyAiData.StartAnimation();
            if(_enemyAiData.CheckFlip())
                _enemyAiAction.Flip(_enemyAiData.LocalScale);
        }
    }
}