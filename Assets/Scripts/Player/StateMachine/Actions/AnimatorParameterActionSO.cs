using System;
using StateMachine.Core;
using StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimatorParameterAction", menuName = "State Machines/Actions/Set Animator Parameter")]
public class AnimatorParameterActionSO : StateActionSO
{
    public ParameterType parameterType = default;
    public string parameterName = default;

    public bool boolValue = default;
    public int intValue = default;
    public float floatValue = default;

    public StateAction.SpecificMoment whenToRun = default; 
    protected override StateAction CreateAction()
    {
        return new AnimatorParameterAction(Animator.StringToHash(parameterName));
    }
    
    public enum ParameterType
    {
        Bool, Int, Float, Trigger
    }
}

public class AnimatorParameterAction : StateAction
{
    private Animator _animator;
    private AnimatorParameterActionSO _originSO => (AnimatorParameterActionSO)base.OriginSO;
    private int _parameterHash;

    public AnimatorParameterAction(int parameterHash)
    {
        _parameterHash = parameterHash;
    }
    
    public override void Awake(StateMachine.Core.StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponent<Animator>();
    }

    public override void OnEnterState()
    {
        if (_originSO.whenToRun == SpecificMoment.OnEnterState)
            SetParameter();
    }

    public override void OnExitState()
    {
        if (_originSO.whenToRun == SpecificMoment.OnStateExit)
            SetParameter();
    }
    
    private void SetParameter()
    {
        switch (_originSO.parameterType)
        {
            case AnimatorParameterActionSO.ParameterType.Bool:
                _animator.SetBool(_parameterHash, _originSO.boolValue);
                break;
            case AnimatorParameterActionSO.ParameterType.Int:
                _animator.SetInteger(_parameterHash, _originSO.intValue);
                break;
            case AnimatorParameterActionSO.ParameterType.Float:
                _animator.SetFloat(_parameterHash, _originSO.floatValue);
                break;
            case AnimatorParameterActionSO.ParameterType.Trigger:
                _animator.SetTrigger(_parameterHash);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public override void OnUpdate()
    {
        
    }
}
