using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [CreateAssetMenu(fileName = "IntEventSO", menuName = "EventSO/IntEventSO")]
    public class IntEventSO : ScriptableObject
    {
        public UnityAction<int> onRaisedEvent;

        public void RaiseEvent(int value)
        {
            onRaisedEvent?.Invoke(value);
        }
    }
}