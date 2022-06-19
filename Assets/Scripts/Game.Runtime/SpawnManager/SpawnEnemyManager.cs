using Enemy.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager
{
    public class SpawnEnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform leftSpawnPos;
        [SerializeField] private Transform rightSpawnPos;
        [SerializeField] private EnemySpawner[] enemySpawners;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnEnemy), 2f, 2f);
        }

        private void SpawnEnemy()
        {
            var enemy = GetRandomEnemy();
            var spawnPos = GetRandomSpawnPos(enemy);
            enemy.Init(spawnPos, playerTransform);
        }

        private BaseEnemy GetRandomEnemy()
        {
            var ranIndex = Random.Range(0, enemySpawners.Length);
            var enemy = enemySpawners[ranIndex].GetEnemy();
            return enemy;
        }

        private Vector3 GetRandomSpawnPos(BaseEnemy enemy)
        {
            var ran = Random.Range(0, 2);

            var zPos = GetEnemyZPos(enemy);

            switch (ran)
            {
                case 0:
                    return leftSpawnPos.position + zPos;
                case 1:
                    return rightSpawnPos.position + zPos;
                default:
                    return Vector3.zero;
            }
        }

        private static Vector3 GetEnemyZPos(BaseEnemy enemy)
        {
            var enemyPos = enemy.transform.position;

            return new Vector3(0, 0, enemyPos.z);
        }
    }
}