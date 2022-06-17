using System.Collections;
using CombatSystem;
using UnityEngine;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerDataSo;
        [SerializeField] private VoidEventSO onPerformFirstSkill;
        
        private int _currentHp;
        private int _attackBuff;
        
        public int Speed => playerDataSo.Speed;

        public float TimeCoolDownFirstSkill{ get; private set; }
        public float TimeCoolDownSecondSkill { get; private set; }
        public float KnockBackValue => playerDataSo.KnockBackValue;
        public bool IsAnimationFinish { get; private set; }
        public bool IsHurt { get; private set; }
        public bool IsDeath { get; private set; }

        private void OnEnable()
        {
            _currentHp = playerDataSo.MaxHp;
            IsDeath = false;
        }

        public int CalculateNormalDame() => playerDataSo.NormalDame + _attackBuff;
        public int CalculateFirstSkillDame() => playerDataSo.FirstSkillDame + _attackBuff;
        public int CalculateSecondSkillDame() => playerDataSo.SecondSkillDame + _attackBuff;
        
        public void OnHurt(Damager damager, Damageable damageable, int dame, float knockBackValue)
        {
            _currentHp -= dame;
            if (_currentHp <= 0)
            {
                damageable.onDie?.Invoke(damager, damageable, dame, knockBackValue);
                IsDeath = true;
            }
                
            else
                IsHurt = true;
        }

        public void ResetHurt() => IsHurt = false;

        public void Heal(int value)
        {
            _currentHp += value;
            _currentHp = Mathf.Clamp(_currentHp, 0, playerDataSo.MaxHp);
        }

        public void BuffAttack(int attackBuff, float timeCoolDownAttackBuff)
        {
            _attackBuff = attackBuff;
            StartCoroutine(CountDownAttackBuff(timeCoolDownAttackBuff));
        }
        
        IEnumerator CountDownAttackBuff(float timeCoolDownAttackBuff)
        {
            yield return new WaitForSeconds(timeCoolDownAttackBuff);
            _attackBuff = 0;
        }

        public void PerformFirstSkill()
        {
            TimeCoolDownFirstSkill = playerDataSo.TimeCoolDownFirstSkill;
            onPerformFirstSkill.RaiseEvent();
            StartCoroutine(CountDownTimeFirstSkill());
        }

        public void PerformSecondSkill()
        {
            TimeCoolDownSecondSkill = playerDataSo.TimeCoolDownSecondSkill;
            StartCoroutine(CountDownTimeSecondSkill());
        }

        IEnumerator CountDownTimeFirstSkill()
        {
            while (TimeCoolDownFirstSkill >= 0)
            {
                TimeCoolDownFirstSkill -= Time.deltaTime;
                yield return null;
            }

            TimeCoolDownFirstSkill = 0;
        }
        IEnumerator CountDownTimeSecondSkill()
        {
            while (TimeCoolDownSecondSkill >= 0)
            {
                TimeCoolDownSecondSkill -= Time.deltaTime;
                yield return null;
            }

            TimeCoolDownSecondSkill = 0;
        }
        
        public void StartAnimation() => IsAnimationFinish = false;
        private void FinishAnimation() => IsAnimationFinish = true;
    }
}