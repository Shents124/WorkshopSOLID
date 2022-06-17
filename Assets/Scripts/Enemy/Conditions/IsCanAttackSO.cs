using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Conditions
{
    [CreateAssetMenu(fileName = "IsCanAttackCondition", menuName = "State Machines/Enemy/Conditions/Is Can Attack Condition")]
    public class IsCanAttackSO : StateConditionSO
    {
        protected override Condition CreateCondition()
        {
            return new IsCanAttack();
        }
    }
    
    public class IsCanAttack : Condition
    {
        private EnemyAIData _enemyAiData;
        
        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
        }

        protected override bool Statement()
        {
            return _enemyAiData.CanAttack();
        }
    }
}