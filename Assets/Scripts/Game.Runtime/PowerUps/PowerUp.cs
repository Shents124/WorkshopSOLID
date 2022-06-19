using UnityEngine;
using UnityEngine.Pool;

namespace PowerUps
{
    public abstract class PowerUp : MonoBehaviour
    {
        private ObjectPool<PowerUp> _pool;

        public void SetPool(ObjectPool<PowerUp> pool) => _pool = pool;

        private void Release()
        {
            _pool.Release(this);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") == false)
            {
                return;
            }

            ApplyEffect();
            Release();

        }

        protected abstract void ApplyEffect();
    }
}