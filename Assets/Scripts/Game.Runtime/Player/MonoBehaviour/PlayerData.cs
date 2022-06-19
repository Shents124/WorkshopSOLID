using System.Runtime.CompilerServices;
using CombatSystem;
using EventSO;
using UnityEngine;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private AttackBuffSO attackBuffSo;
        [SerializeField] private FloatEventSO onCountDownFirstSkill;
        [SerializeField] private FloatEventSO onCountDownSecondSkill;
        [SerializeField] private VoidEventSO onHealthChange;
        [SerializeField] private IntEventSO onHeal;
        
        private int _currentHp;
        private bool _canTakeDame;
        private float _currentTimeCoolDownFirstSkill;
        private float _currentTimeCoolDownSecondSkill;

        public int CurrentHp => _currentHp <= 0 ? 0 : _currentHp;
        public int MaxHp => playerDataSo.MaxHp;
        public int AttackBuff => attackBuffSo.AttackBuff;
        public int Speed => playerDataSo.Speed;
        public float CurrentTimeCoolDownFirstSkill => _currentTimeCoolDownFirstSkill;
        public float CurrentTimeCoolDownSecondSkill => _currentTimeCoolDownSecondSkill;
        public float TimeCoolDownFirstSkill => playerDataSo.TimeCoolDownFirstSkill;
        public float TimeCoolDownSecondSkill => playerDataSo.TimeCoolDownSecondSkill;
        public float KnockBackValue => playerDataSo.KnockBackValue;
        public bool IsAnimationFinish { get; private set; }
        public bool IsHurt { get; private set; }
        public bool IsDeath { get; private set; }

        private void OnEnable()
        {
            _currentHp = playerDataSo.MaxHp;
            IsDeath = false;
            _canTakeDame = true;
            onHeal.onRaisedEvent += Heal;
        }

        private void OnDisable()
        {
            onHeal.onRaisedEvent -= Heal;
        }

        private void Update()
        {
            CountDownFirstSkill();
            CountDownSecondSkill();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CalculateNormalDame() => playerDataSo.NormalDame + attackBuffSo.AttackBuff;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CalculateFirstSkillDame() => playerDataSo.FirstSkillDame + attackBuffSo.AttackBuff;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CalculateSecondSkillDame() => playerDataSo.SecondSkillDame + attackBuffSo.AttackBuff;
        
        public void OnHurt(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            if(_canTakeDame == false)
                return;
            
            _currentHp -= dame;
            onHealthChange.RaiseEvent();
            IsHurt = true;
            if (_currentHp > 0)
            {
                return;
            }

            damageable.onDie?.Invoke(damager, damageable, dame, knockBackValue);
            IsDeath = true;
            _canTakeDame = false;
        }

        public void ResetHurt() => IsHurt = false;

        private void Heal(int value)
        {
            _currentHp += value;
            _currentHp = Mathf.Clamp(_currentHp, 0, playerDataSo.MaxHp);
            onHealthChange.RaiseEvent();
        }
        
        public void PerformFirstSkill()
        {
            _currentTimeCoolDownFirstSkill = playerDataSo.TimeCoolDownFirstSkill;
        }

        public void PerformSecondSkill()
        {
            _currentTimeCoolDownSecondSkill = playerDataSo.TimeCoolDownSecondSkill;
        }

        private void CountDownFirstSkill()
        {
            CountDownTimeSkill(ref _currentTimeCoolDownFirstSkill);
            onCountDownFirstSkill.RaiseEvent(_currentTimeCoolDownFirstSkill);
        }

        private void CountDownSecondSkill()
        {
            CountDownTimeSkill(ref _currentTimeCoolDownSecondSkill);
            onCountDownSecondSkill.RaiseEvent(_currentTimeCoolDownSecondSkill);
        }
        
        private static void CountDownTimeSkill(ref float timeCoolDown)
        {
            if (timeCoolDown <= 0)
            {
                timeCoolDown = 0;
                return;
            }
            
            timeCoolDown -= Time.deltaTime;
        }
        
        public void StartAnimation() => IsAnimationFinish = false;
        private void FinishAnimation() => IsAnimationFinish = true;
    }
}