using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(fileName = "AttackBuffDataSO", menuName = "Data/Attack Buff Data")]
    public class AttackBuffDataSO : ScriptableObject
    {
        [SerializeField] private int attackBuff;
        [SerializeField] private float duration;

        public int AttackBuff => attackBuff;

        public float Duration => duration;
    }
}