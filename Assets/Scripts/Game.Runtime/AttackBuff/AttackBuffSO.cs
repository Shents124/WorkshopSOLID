using UnityEngine;

[CreateAssetMenu(fileName = "AttackBuffSO", menuName = "AttackBuffSO")]
public class AttackBuffSO : ScriptableObject
{
    public int AttackBuff;
    public float Duration;
    
    public void ApplyAttackEffect(int attackBuff, float duration)
    {
        AttackBuff += attackBuff;
        Duration += duration;
    }

    public void ResetAttackBuff()
    {
        AttackBuff = 0;
        Duration = 0;
    }
}