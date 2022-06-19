using UnityEngine;
using UnityEngine.Pool;

namespace Enemy.Core
{
    public class BaseEnemy : MonoBehaviour
    {
        private EnemyAIData _enemyAiData;
        private IObjectPool<BaseEnemy> _pool;

        private void Awake()
        {
            _enemyAiData = GetComponent<EnemyAIData>();
        }
        
        public void Init(Vector3 position, Transform playerTransform)
        {
            _enemyAiData.InitEnemy(playerTransform);
            transform.position = position;
        }

        public void SetPool(IObjectPool<BaseEnemy> pool) => _pool = pool;

        private void OnDeathAnimationFinish()
        {
            _pool.Release(this);
        }
    }
}