using PowerUps;
using UnityEngine;
using UnityEngine.Pool;

namespace SpawnManager
{
    public class PowerUpSpawn : MonoBehaviour
    {
        [SerializeField] private PowerUp powerUpPrefab;
        private ObjectPool<PowerUp> _pool;

        private void Start()
        {
            _pool = new ObjectPool<PowerUp>(CreateEnemy, OnTakePowerUp, OnReturnPowerUp);
        }

        private PowerUp CreateEnemy()
        {
            var powerUp = Instantiate(powerUpPrefab, transform, true);
            powerUp.SetPool(_pool);
            return powerUp;
        }

        private void OnTakePowerUp(PowerUp powerUp)
        {
            powerUp.gameObject.SetActive(true);
        }

        private void OnReturnPowerUp(PowerUp powerUp)
        {
            powerUp.gameObject.SetActive(false);
        }

        public PowerUp GetPowerUp()
        {
            var powerUp = _pool.Get();
            return powerUp;
        }
    }
}
