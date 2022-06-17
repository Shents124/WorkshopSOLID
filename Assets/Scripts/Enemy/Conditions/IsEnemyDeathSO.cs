using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Conditions
{
    [CreateAssetMenu(fileName = "IsEnemyDeathCondition", menuName = "State Machines/Enemy/Conditions/Is Enemy Death Condition")]
    public class IsEnemyDeathSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsEnemyDeath();
        }
    }
    public class IsEnemyDeath : Condition
    {
        private EnemyAIData _enemyAiData;
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
        }

        protected override bool Statement()
        {
            return _enemyAiData.IsDeath;
        }
    }
}