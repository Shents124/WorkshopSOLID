using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [CreateAssetMenu(fileName = "NewVoidEventSO", menuName = "EventSO/VoidEventSO")]
    public class VoidEventSO : ScriptableObject
    {
        public UnityAction onEventRaised;

        public void RaiseEvent()
        {
            onEventRaised?.Invoke();
        }
    }
}
