using EventSO;
using UnityEngine;

namespace PowerUps
{
    public class HealPowerUp : PowerUp
    {
        [SerializeField] private HealthHealDataSO healDataSo;
        [SerializeField] private IntEventSO onHealEvent;

        protected override void ApplyEffect()
        {
            onHealEvent.RaiseEvent(healDataSo.HealValue);
        }
    }
}