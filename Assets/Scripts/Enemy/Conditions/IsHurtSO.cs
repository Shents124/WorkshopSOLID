using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Conditions
{
    [CreateAssetMenu(fileName = "IsHurtCondition", menuName = "State Machines/Enemy/Conditions/Is Hurt")]
    public class IsHurtSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsHurtCondition();
        }
    }
    
    public class IsHurtCondition : Condition
    {
        private EnemyAIData _enemyAiData;
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
        }

        protected override bool Statement()
        {
            return _enemyAiData.IsHurt;
        }
    }
}