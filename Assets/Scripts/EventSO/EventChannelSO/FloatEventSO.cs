using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [CreateAssetMenu(fileName = "FloatEventSO", menuName = "EventSO/FloatEventSO")]
    public class FloatEventSO : ScriptableObject
    {
        public UnityAction<float> onRaisedEvent;

        public void RaiseEvent(float value)
        {
            onRaisedEvent?.Invoke(value);
        }
    }
}