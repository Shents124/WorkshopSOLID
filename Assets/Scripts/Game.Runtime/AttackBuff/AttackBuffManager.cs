using System.Collections;
using EventSO;
using UnityEngine;

namespace AttackBuff
{
    public class AttackBuffManager : MonoBehaviour
    {
        [SerializeField] private AttackBuffSO attackBuffSo;
        [SerializeField] private AttackBuffEventSO onGetAttackBuffEvent;
        [SerializeField] private VoidEventSO onAttackBuffChangeEvent;
        
        private bool _isCountDown;
        private void OnEnable()
        {
            onGetAttackBuffEvent.onRaisedEvent += OnGetAttackBuff;
        }

        private void OnDisable()
        {
            onGetAttackBuffEvent.onRaisedEvent -= OnGetAttackBuff;
        }

        private void Start()
        {
            attackBuffSo.ResetAttackBuff();
            _isCountDown = false;
        }
        
        private void OnGetAttackBuff(int attack, float duration)
        {
            attackBuffSo.ApplyAttackEffect(attack, duration);
            onAttackBuffChangeEvent.RaiseEvent();
            
            if (_isCountDown)
            {
                return;
            }

            StartCoroutine(CountDown());
            _isCountDown = true;
        }

        IEnumerator CountDown()
        {
            while (attackBuffSo.Duration > 0)
            {
                attackBuffSo.Duration -= Time.deltaTime;
                yield return null;
            }
            attackBuffSo.ResetAttackBuff();
            _isCountDown = false;
            onAttackBuffChangeEvent.RaiseEvent();
        }
    }
}