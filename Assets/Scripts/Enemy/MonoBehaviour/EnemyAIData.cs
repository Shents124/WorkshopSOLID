using CombatSystem;
using Enemy.Data;
using EventSO;
using UnityEngine;

namespace Enemy.Core
{
    public class EnemyAIData : MonoBehaviour
    {
        [SerializeField] private VoidEventSO onPlayerDeath;
        [SerializeField] private VoidEventSO onSwapPlayerWhenDie;
        [SerializeField] private EnemyDataSO enemyDataSo;
        
        private Transform _playerTransform;
        private int _currentHp;
        private bool _isFacingRight;
        private Vector3 _localScale;
        private DetectorAI _detectorAi;

        public int Hp => enemyDataSo.Hp;
        public int Speed => enemyDataSo.Speed;
        public int Attack => enemyDataSo.Attack;
        public float KnockBackValue => enemyDataSo.KnockBackValue;
        public Vector3 LocalScale => _localScale;
        public int MoveDirection => _isFacingRight ? 1 : -1;
        public bool IsHurt { get; private set; }
        public bool IsDeath { get; private set; }
        public bool IsAnimationFinish { get; private set; }
        public bool IsStopAction { get; private set; }
        
        private void Awake()
        {
            _detectorAi = GetComponentInChildren<DetectorAI>();
        }

        private void OnEnable()
        {
            _currentHp = enemyDataSo.Hp;
            IsDeath = false;
            IsStopAction = false;

            onPlayerDeath.onEventRaised += OnPlayerDeath;
            onSwapPlayerWhenDie.onEventRaised += OnSwapPlayerWhenDie;
        }

        private void OnDisable()
        {
            onPlayerDeath.onEventRaised -= OnPlayerDeath;
            onSwapPlayerWhenDie.onEventRaised -= OnSwapPlayerWhenDie;
            
        }

        public void InitEnemy(Transform playerTransform)
        {
            _isFacingRight = false;
            _localScale = Vector3.one;
            transform.localScale = _localScale;
            _playerTransform = playerTransform;
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            var newLocalScale = new Vector3(_localScale.x * -1, _localScale.y, _localScale.z);
            _localScale = newLocalScale;
        }

        public bool CanAttack()
        {
            return _detectorAi.IsDetectedPlayer;
        }

        public bool CheckFlip()
        {
            var posX = transform.position.x;
            if ((_isFacingRight && posX > _playerTransform.position.x)
                || (_isFacingRight == false && posX < _playerTransform.position.x))
            {
                Flip();
                return true;
            }

            return false;
        }

        public void OnHurt(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            _currentHp -= dame;
            IsHurt = true;
            if (_currentHp > 0)
            {
                return;
            }

            damageable.onDie?.Invoke(damager, damageable, dame, knockBackValue);
            IsDeath = true;
        }

        public void ResetHurt() => IsHurt = false;

        private void OnPlayerDeath()
        {
            IsStopAction = true;
        }

        private void OnSwapPlayerWhenDie()
        {
            IsStopAction = false;
        }

        public void StartAnimation() => IsAnimationFinish = false;
        private void FinishAnimation() => IsAnimationFinish = true;
    }
}