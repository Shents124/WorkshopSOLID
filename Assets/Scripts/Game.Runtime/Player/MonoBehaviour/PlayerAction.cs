using CombatSystem;
using EventSO;
using UnityEngine;

namespace Player
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField] private Damager normalAttack;
        [SerializeField] private Damager skill1;
        [SerializeField] private Damager skill2;
        [SerializeField] private VoidEventSO onDie;

        private PlayerData _playerData;
        private Rigidbody2D _rb2D;

        private void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _playerData = GetComponent<PlayerData>();
        }
        
        public void Move(float horizontalInput, float speed)
        {
            _rb2D.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, _rb2D.velocity.y);
            Flip(horizontalInput);
        }

        private void Flip(float horizontalInput)
        {
            var newScale = new Vector3(horizontalInput, 1, 1);
            transform.localScale = newScale;
        }

        public void OnHurt(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            var dameDirection = damageable.DameDirection;
            _rb2D.velocity = new Vector2(dameDirection.x * knockBackValue, _rb2D.velocity.y);
        }
        
        public void OnDie(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            onDie.RaiseEvent();
        }
        
        //Attach to Animation Event
        public void NormalAttack()
        {
            normalAttack.DealDamage(_playerData.CalculateNormalDame(), _playerData.KnockBackValue);
        }

        //Attach to Animation Event
        public void PerformSkill_1()
        {
            skill1.DealDamage(_playerData.CalculateFirstSkillDame(), _playerData.KnockBackValue);
        }

        //Attach to Animation Event
        public void PerformSkill_2()
        {
            skill2.DealDamage(_playerData.CalculateSecondSkillDame(), _playerData.KnockBackValue);
        }
    }
}