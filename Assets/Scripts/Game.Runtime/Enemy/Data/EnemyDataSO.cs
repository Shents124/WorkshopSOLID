using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/EnemyData")]
    public class EnemyDataSO : ScriptableObject
    {
        [SerializeField] private int hp;
        [SerializeField] private int speed;
        [SerializeField] private int attack;
        [SerializeField] private float knockBackValue;

        public int Hp => hp;

        public int Speed => speed;

        public int Attack => attack;

        public float KnockBackValue => knockBackValue;
    }
}