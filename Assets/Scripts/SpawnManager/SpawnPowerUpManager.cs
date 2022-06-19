using EventSO;
using PowerUps;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnManager
{
    public class SpawnPowerUpManager : MonoBehaviour
    {
        [SerializeField] private int rateSpawn = 2;
        [SerializeField] private PowerUpSpawn[] powerUpSpawns;
        [SerializeField] private Vector3EventSO onEnemyDie;
        
        private void OnEnable()
        {
            onEnemyDie.onRaisedEvent += SpawnPowerUp;
        }

        private void OnDisable()
        {
            onEnemyDie.onRaisedEvent -= SpawnPowerUp;
        }

        private void SpawnPowerUp(Vector3 position)
        {
            if (CanSpawn() == false)
            {
                return;
            }

            var powerUp = GetRandomPowerUp();
            powerUp.transform.position = position;
        }

        private PowerUp GetRandomPowerUp()
        {
            var ranIndex = Random.Range(0, powerUpSpawns.Length);
            var powerUp = powerUpSpawns[ranIndex].GetPowerUp();
            return powerUp;
        }

        private bool CanSpawn()
        {
            var ran = Random.Range(0, 10);
            return ran <= rateSpawn;
        }
    }
}