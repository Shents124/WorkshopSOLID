using Input;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "IsAttackNormalAttackCondition", menuName = "State Machines/Player/Conditions/Is Normal Attack")]
public class IsNormalAttackSO : StateConditionSO
{
    protected override Condition CreateCondition()
    {
        return new IsNormalAttack();
    }
}

public class IsNormalAttack : Condition
{
    private PlayerInputController _playerInputController;
    
    public override void Awake(StateMachine.Core.StateMachine stateMachine)
    {
        _playerInputController = stateMachine.GetComponent<PlayerInputController>();
    }

    protected override bool Statement()
    {
        return _playerInputController.NormalAttack;
    }
}
