using System;
using UnityEngine;
using UnityEngine.Events;

namespace CombatSystem
{
    public class Damageable : MonoBehaviour
    {
        [Serializable]
        public class DamageEvent : UnityEvent<Damager, Damageable, int, float>
        {
        }

        public DamageEvent onTakeDame;
        public DamageEvent onDie;
        public Vector2 DameDirection { get; private set; }

        public void TakeDamage(Damager damager, int dame, float knockBackValue)
        {
            DameDirection = transform.position - damager.transform.position;
            onTakeDame?.Invoke(damager, this, dame, knockBackValue);
        }
    }
}