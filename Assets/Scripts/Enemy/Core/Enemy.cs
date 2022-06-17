using UnityEngine;

namespace Enemy.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        private EnemyAIData _enemyAiData;
        private EnemyAIAction _enemyAiAction;

        private void Awake()
        {
            _enemyAiData = GetComponent<EnemyAIData>();
            _enemyAiAction = GetComponent<EnemyAIAction>();
        }

        private void Start()
        {
            _enemyAiData.InitEnemy(false);
        }
        
    }
}