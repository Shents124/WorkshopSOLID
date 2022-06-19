using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [CreateAssetMenu(fileName = "AttackBuffEventSO", menuName = "EventSO/AttackBuffEventSO")]
    public class AttackBuffEventSO : ScriptableObject
    {
        public UnityAction<int, float> onRaisedEvent;

        public void RaiseEvent(int arg0, float arg1)
        {
            onRaisedEvent?.Invoke(arg0, arg1);
        }
    }
}