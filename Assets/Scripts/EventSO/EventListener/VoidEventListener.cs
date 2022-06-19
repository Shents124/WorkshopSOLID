using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    public class VoidEventListener : MonoBehaviour
    {
        [SerializeField]
        public UnityEvent voidGameEvent;
        public VoidEventSO voidEventSo;

        private void OnEnable()
        {
            voidEventSo.onEventRaised += Respond;
        }

        private void OnDisable()
        {
            voidEventSo.onEventRaised -= Respond;
        }

        private void Respond()
        {
            voidGameEvent?.Invoke();
        }
    }
}
