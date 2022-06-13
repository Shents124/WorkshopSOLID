using UnityEngine;

namespace StateMachine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New TransitionItemSO", menuName = "State Machine/Transition Item SO")]
    public class TransitionItemSO : ScriptableObject
    {
        public StateSO fromState;
        public TransitionItem[] transitionItems;
    }
}