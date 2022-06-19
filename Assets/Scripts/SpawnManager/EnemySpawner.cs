using Enemy.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace SpawnManager
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private BaseEnemy prefab;
        
        private ObjectPool<BaseEnemy> _pool;
        
        private Vector3 _currentVector = new Vector3(0,0,0);
        
        private readonly Vector3 _plusVector = new Vector3(0,0,1);
        
        private void Start()
        {
            _pool = new ObjectPool<BaseEnemy>(CreateEnemy, OnTakeEnemy, OnReturnEnemy);
        }

        private BaseEnemy CreateEnemy()
        {
            var enemy = Instantiate(prefab, transform, true);
            
            _currentVector += _plusVector;
            enemy.transform.position = _currentVector;
            
            enemy.SetPool(_pool);
            return enemy;
        }

        private void OnTakeEnemy(BaseEnemy enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        private void OnReturnEnemy(BaseEnemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        public BaseEnemy GetEnemy()
        {
            var enemy = _pool.Get();
            return enemy;
        }
    }
}