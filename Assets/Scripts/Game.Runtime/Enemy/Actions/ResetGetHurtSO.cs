using Enemy.Core;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace Enemy.Actions
{
    [CreateAssetMenu(fileName = "ResetGetHurt", menuName = "State Machines/Enemy/Actions/Reset Get Hurt")]
    public class ResetGetHurtSO : StateActionSO
    {
        protected override StateAction CreateAction()
        {
            return new ResetGetHurt();
        }
    }

    public class ResetGetHurt : StateAction
    {
        private EnemyAIData _enemyAiData;

        public override void Awake(StateMachine.Core.StateMachine stateMachine)
        {
            _enemyAiData = stateMachine.GetComponent<EnemyAIData>();
        }

        public override void OnExitState()
        {
            _enemyAiData.ResetHurt();
        }
    }
}