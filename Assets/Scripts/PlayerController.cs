using System;
using Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    private PlayerInputController _playerInputController;
    
    [SerializeField] private float speed;
    
    private Rigidbody2D _rigidbody2D;
    private float _horizontalInput;
    private bool _isRun;
    [SerializeField] private Animator animator;
    private static readonly int s_run = Animator.StringToHash("Run");
    private static readonly int s_attack1 = Animator.StringToHash("Attack_1");

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputReader.NormalAttackEvent += OnAttack;
    }

    private void OnDisable()
    {
        inputReader.NormalAttackEvent += OnAttack;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = _playerInputController.HorizontalInput; 
        _isRun = Math.Abs(_horizontalInput) > 0.1f;
        animator.SetBool(s_run, _isRun);
        
        // if (_playerInputController.NormalAttack)
        // {
        //     Debug.Log(_playerInputController.NormalAttack);
        //     animator.SetTrigger(s_attack1);
        // }
                
        Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalInput * speed * Time.deltaTime, _rigidbody2D.velocity.y);
    }

    private void OnAttack()
    {
        animator.SetTrigger(s_attack1);
    }
    private void Flip()
    {
        if (_isRun == false)
        {
            return;
        }

        var newScale = new Vector3(_horizontalInput, 1, 1);
        transform.localScale = newScale;
    }
    
}
