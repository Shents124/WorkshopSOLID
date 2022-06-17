using CombatSystem;
using UnityEngine;

namespace Enemy.Core
{
    public class EnemyAIAction : MonoBehaviour
    {
        [SerializeField] private Damager normalAttack;
        private EnemyAIData _enemyAiData;
        private Rigidbody2D _rb2d;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _enemyAiData = GetComponent<EnemyAIData>();
        }

        public void Flip(Vector3 localScale)
        {
            transform.localScale = localScale;
        }

        public void Move(int speed, int direction)
        {
            _rb2d.velocity = new Vector2(speed * direction * Time.deltaTime, _rb2d.velocity.y);
        }

        public void NormalAttack()
        {
            normalAttack.DealDamage(_enemyAiData.Attack, _enemyAiData.KnockBackValue);
        }

        public void OnHurt(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            var dameDirection = damageable.DameDirection;
            _rb2d.velocity = new Vector2(dameDirection.x * knockBackValue, _rb2d.velocity.y);
        }

        public void OnDie(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            //
        }

        private void DisableGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}