using UnityEngine;

namespace Input
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        public float HorizontalInput { get; private set; }
        public bool NormalAttack { get; private set; }
        public bool PerformSkill_1 { get; private set; }
        public bool PerformSkill_2 { get; private set; }

        private void OnEnable()
        {
            inputReader.EnableInput();
            
            inputReader.MoveEvent += OnMove;
            inputReader.NormalAttackEvent += OnStartedNormaAttack;
            inputReader.NormalAttackCanceledEvent += OnNormalAttackCanceled;
            inputReader.Skill1Event += OnStartedSkill1;
            inputReader.Skill1CanceledEvent += OnSkill1Canceled;
            inputReader.Skill2Event += OnStartedSkill2;
            inputReader.Skill2CanceledEvent += OnSkill2Canceled;
        }

        private void OnDisable()
        {
            inputReader.MoveEvent -= OnMove;
            inputReader.NormalAttackEvent -= OnStartedNormaAttack;
            inputReader.NormalAttackCanceledEvent -= OnNormalAttackCanceled;
            inputReader.Skill1Event -= OnStartedSkill1;
            inputReader.Skill1CanceledEvent -= OnSkill1Canceled;
            inputReader.Skill2Event -= OnStartedSkill2;
            inputReader.Skill2CanceledEvent -= OnSkill2Canceled;
        }

        
        public void DisableInput()
        {
            inputReader.DisableInput();
        }
        
        private void OnMove(float value) => HorizontalInput = value;

        private void OnStartedNormaAttack() => NormalAttack = true;
        private void OnNormalAttackCanceled() => NormalAttack = false;

        private void OnStartedSkill1() => PerformSkill_1 = true;
        private void OnSkill1Canceled() => PerformSkill_1 = false;
        
        private void OnStartedSkill2() => PerformSkill_2 = true;
        private void OnSkill2Canceled() => PerformSkill_2 = false;
    }
}
