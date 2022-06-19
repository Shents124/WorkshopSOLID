using EventSO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GameUI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI hp;
        
        public void SetHealth(int currentHp, int maxHp)
        {
            slider.maxValue = maxHp;
            slider.value = currentHp;
            SetHealthText(currentHp, maxHp);
        }

        private void SetHealthText(int currentHp, int maxHp)
        {
            hp.text = $"{currentHp}/{maxHp}";
        }
    }
}