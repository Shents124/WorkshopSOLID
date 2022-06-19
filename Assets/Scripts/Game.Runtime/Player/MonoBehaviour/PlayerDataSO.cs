using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [SerializeField] private int maxHp;
        [SerializeField] private int speed;
        [SerializeField] private int normalDame;
        [SerializeField] private int firstSkillDame;
        [SerializeField] private float timeCoolDownFirstSkill;
        [SerializeField] private int secondSkillDame;
        [SerializeField] private float timeCoolDownSecondSkill;
        [SerializeField] private float knockBackValue;

        public int MaxHp => maxHp;

        public int Speed => speed;

        public int NormalDame => normalDame;

        public int FirstSkillDame => firstSkillDame;

        public float TimeCoolDownFirstSkill => timeCoolDownFirstSkill;

        public int SecondSkillDame => secondSkillDame;

        public float TimeCoolDownSecondSkill => timeCoolDownSecondSkill;

        public float KnockBackValue => knockBackValue;
    }
}