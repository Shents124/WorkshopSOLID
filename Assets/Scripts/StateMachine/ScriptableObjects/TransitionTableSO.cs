using System;
using System.Collections.Generic;
using StateMachine.Core;
using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewTransitionTable", menuName = "State Machine/Transition Table")]
    public class TransitionTableSO : ScriptableObject
    {
        [SerializeField] private TransitionItemSO[] transitionItems = default;

        internal State GetInitialState(Core.StateMachine stateMachine)
        {
            var states = new List<State>();
            var transitions = new List<StateTransition>();
            var createdInstances = new Dictionary<ScriptableObject, object>();
            
            foreach (var item in transitionItems)
            {
                if (item.fromState == null)
                    throw new ArgumentNullException(nameof(item.fromState), $"TransitionTable: {name}");

                var state = item.fromState.GetState(stateMachine, createdInstances);
                states.Add(state);

                transitions.Clear();

                foreach (var transitionItem in item.transitionItems)
                {
                    if (transitionItem.toState == null)
                        throw new ArgumentNullException(nameof(transitionItem.toState),
                            $"TransitionTable: {name}, From State: {item.fromState.name}");

                    var toState = transitionItem.toState.GetState(stateMachine, createdInstances);
                    ProcessConditionUsages(stateMachine, transitionItem.conditions, createdInstances,
                        out var conditions, out var resultGroups);
                    transitions.Add(new StateTransition(toState, conditions, resultGroups));
                }

                state._transitions = transitions.ToArray();
            }
            
            return states.Count > 0
                ? states[0]
                : throw new InvalidOperationException($"TransitionTable {name} is empty");
        }

        private static void ProcessConditionUsages(Core.StateMachine stateMachine, IList<ConditionUsage> conditionUsages,
            Dictionary<ScriptableObject, object> createdInstances, out StateCondition[] conditions,
            out int[] resultGroups)
        {
            int count = conditionUsages.Count;
            conditions = new StateCondition[count];
            for (int i = 0; i < count; i++)
                conditions[i] = conditionUsages[i].condition.GetCondition(stateMachine,
                    conditionUsages[i].expectedResult == Result.True, createdInstances);

            List<int> resultsGroupList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                int idx = resultsGroupList.Count;
                resultsGroupList.Add(1);
                while (i < count - 1 && conditionUsages[i].operatorCondition == Operator.And)
                {
                    i++;
                    resultsGroupList[idx]++;
                }
            }

            resultGroups = resultsGroupList.ToArray();
        }
    }
    [Serializable]
    public struct TransitionItem
    {
        public StateSO toState;
        public ConditionUsage[] conditions;
    }

    [Serializable]
    public struct ConditionUsage
    {
        public Result expectedResult;
        public StateConditionSO condition;
        public Operator operatorCondition;
    }

    public enum Result
    {
        True, False
    }

    public enum Operator
    {
        And, Or
    }
}