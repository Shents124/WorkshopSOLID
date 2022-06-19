using System;
using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [Serializable]
    public class FloatUnityEvent : UnityEvent<float>
    {
        
    }
    
    public class FloatEventListener : MonoBehaviour
    {
        public FloatUnityEvent floatUnityEvent;
        public FloatEventSO floatEventSo;
        
        private void OnEnable()
        {
            floatEventSo.onRaisedEvent += Respond;
        }

        private void OnDisable()
        {
            floatEventSo.onRaisedEvent -= Respond;
        }

        private void Respond(float value)
        {
            floatUnityEvent?.Invoke(value);
        }
    }
}