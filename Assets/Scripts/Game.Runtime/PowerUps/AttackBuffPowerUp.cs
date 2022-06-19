using EventSO;
using UnityEngine;

namespace PowerUps
{
    public class AttackBuffPowerUp : PowerUp
    {
        [SerializeField] private AttackBuffDataSO attackBuffDataSo;
        [SerializeField] private AttackBuffEventSO attackBuffEventSo;

        protected override void ApplyEffect()
        {
            attackBuffEventSo.RaiseEvent(attackBuffDataSo.AttackBuff, attackBuffDataSo.Duration);
        }
    }
}