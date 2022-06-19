using System;
using System.Collections.Generic;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace StateMachine.Core
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private TransitionTableSO transitionTableSo = default;
        
        private readonly Dictionary<Type, Component> _cachedComponents = new Dictionary<Type, Component>();

        internal State _currentState;

        private void Awake()
        {
             //transitionTableSo.InitialState(this);
        }

        private void OnEnable()
        {
            _currentState = transitionTableSo.GetInitialState(this);
            _currentState.OnStateEnter();
        }

        private new bool TryGetComponent<T>(out T component) where T : Component
        {
            var type = typeof(T);
            if (_cachedComponents.TryGetValue(type, out var value) == false)
            {
                if (base.TryGetComponent<T>(out component))
                    _cachedComponents.Add(type, component);

                return component != null;
            }

            component = (T)value;
            return true;
        }

        public new T GetComponent<T>() where T : Component
        {
            return TryGetComponent(out T component)
                ? component
                : throw new InvalidOperationException($"{typeof(T).Name} not found in {name}.");
        }

        private void Update()
        {
            if(_currentState.TryGetTransition(out var transitionState))
                Transition(transitionState);
            _currentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.OnFixedUpdate();
        }

        private void Transition(State transitionState)
        {
            _currentState.OnStateExit();
            _currentState = transitionState;
            _currentState.OnStateEnter();
        }
    }
}