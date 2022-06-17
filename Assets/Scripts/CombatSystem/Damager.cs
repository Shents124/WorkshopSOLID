using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CombatSystem
{
    public class Damager : MonoBehaviour
    {
        [Serializable]
        public class DamageableEvent : UnityEvent<Damager, Damageable>
        {
        }

        [Serializable]
        public class NonDamageableEvent : UnityEvent<Damager>
        {
        }

        public Vector2 offset = new Vector2(1f, 1f);
        public Vector2 size = new Vector2(2.5f, 1f);
        
        [SerializeField] private bool canHitTrigger;
        [SerializeField] private LayerMask hittableLayers;
        [SerializeField] private DamageableEvent onDamageableEvent;
        [SerializeField] private NonDamageableEvent nonDamageableEvent;

        private ContactFilter2D _attackContactFilter;
        private readonly List<Collider2D> _attackOverlapResults = new List<Collider2D>();

        private Collider2D _lastHit;

        private void Awake()
        {
            _attackContactFilter.layerMask = hittableLayers;
            _attackContactFilter.useTriggers = canHitTrigger;
            _attackContactFilter.useLayerMask = true;
        }

        public void DealDamage(int dame, float knockBackValue)
        {
            var scale = transform.lossyScale;
            var scaledSize = Vector2.Scale(size, scale);
            var facingOffset = new Vector2(offset.x * scale.x, offset.y * scale.y);

            var pointA = (Vector2)transform.position + facingOffset - scaledSize * 0.5f;
            var pointB = pointA + scaledSize;

            var hitCount = Physics2D.OverlapArea(pointA, pointB, _attackContactFilter, _attackOverlapResults);

            foreach (Collider2D result in _attackOverlapResults)
            {
                _lastHit = result;
                var damageable = _lastHit.GetComponent<Damageable>();
                if (damageable)
                {
                    onDamageableEvent.Invoke(this, damageable);
                    damageable.TakeDamage(this, dame, knockBackValue);
                }
                else
                    nonDamageableEvent.Invoke(this);
            }
        }
    }
}