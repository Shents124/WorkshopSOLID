using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Conditions
{
    [CreateAssetMenu(fileName = "IsDoneAnimationCondition", menuName = "State Machines/Enemy/Conditions/Is Done Animation")]
    
    public class IsDoneAnimationSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsDoneAnimation();
        }
    }
    
    public class IsDoneAnimation: Condition
    {
        private EnemyAIData _enemyAiData;
        
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
        }

        protected override bool Statement()
        {
            return _enemyAiData.IsAnimationFinish;
        }
    }
}