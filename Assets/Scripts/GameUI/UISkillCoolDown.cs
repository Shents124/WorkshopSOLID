using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UISkillCoolDown : MonoBehaviour
{
    [SerializeField] private Image image;

    private Button _button;
    private float _timeCoolDown;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    
    public void Init(float timeCoolDown)
    {
        _timeCoolDown = timeCoolDown;
        image.fillAmount = 0;
    }
    
    public void StartCountDown(float currentTimeCoolDown)
    {
        if (currentTimeCoolDown <= 0)
        {
            _button.interactable = true;
            return;
        }

        image.fillAmount = CalculateFillAmount(currentTimeCoolDown);
        _button.interactable = false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private float CalculateFillAmount(float time)
    {
        return time / _timeCoolDown;
    }
}
