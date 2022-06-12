using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IPlayerControllerActions
    {
        public event UnityAction<float> MoveEvent = delegate {  };
        public event UnityAction NormalAttackEvent = delegate {  };
        public event UnityAction NormalAttackCanceledEvent = delegate {  };
        public event UnityAction Skill1Event = delegate {  };
        public event UnityAction Skill1CanceledEvent = delegate {  };
        public event UnityAction Skill2Event = delegate {  };
        public event UnityAction Skill2CanceledEvent = delegate {  };

        private GameInput _gameInput;

        private void OnEnable()
        {
            if (_gameInput != null)
            {
                return;
            }

            _gameInput = new GameInput();
            _gameInput.Enable();
            _gameInput.PlayerController.SetCallbacks(this);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent.Invoke(context.ReadValue<float>());
        }

        public void OnNormalAttack(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    NormalAttackEvent.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    NormalAttackCanceledEvent.Invoke();
                    break;
            }
        }

        public void OnSkill_1(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Skill1Event.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    Skill1CanceledEvent.Invoke();
                    break;
            }
        }

        public void OnSkill_2(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Skill2Event.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    Skill2CanceledEvent.Invoke();
                    break;
            }
        }
    }
}
