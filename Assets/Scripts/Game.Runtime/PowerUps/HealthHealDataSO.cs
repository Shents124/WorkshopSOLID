using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(fileName = "HealthHealDataSO", menuName = "Data/Health Heal Data")]
    public class HealthHealDataSO : ScriptableObject
    {
        [SerializeField] private int healValue;

        public int HealValue => healValue;
    }
}