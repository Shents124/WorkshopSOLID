using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [CreateAssetMenu(fileName = "Vector3EventSO", menuName = "EventSO/Vector3EventSO")]
    public class Vector3EventSO : ScriptableObject
    {
        public UnityAction<Vector3> onRaisedEvent;

        public void RaiseEvent(Vector3 arg0)
        {
            onRaisedEvent?.Invoke(arg0);
        }
    }
}