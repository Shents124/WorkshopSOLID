using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Conditions
{
    [CreateAssetMenu(fileName = "IsStopActionSO", menuName = "State Machines/Enemy/Conditions/Is Stop Action")]
    public class IsStopActionSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsStopAction();
        }
    }
    
    public class IsStopAction : Condition
    {
        private EnemyAIData _enemyAiData;
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
        }

        protected override bool Statement()
        {
            return _enemyAiData.IsStopAction;
        }
    }
}