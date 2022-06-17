using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UISkilCoolDown : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private float _timeCoolDown;
    private float _currentTimeCoolDown;

    private void OnEnable()
    {
        _currentTimeCoolDown = _timeCoolDown;
    }

    public void Init(float timeCoolDown)
    {
        _timeCoolDown = timeCoolDown;
    }
    
    public void StartCountDown()
    {
        _currentTimeCoolDown = _timeCoolDown;
        StartCoroutine(CountDownCoroutine());
    }
    
    IEnumerator CountDownCoroutine()
    {
        while (_currentTimeCoolDown > 0)
        {
            _currentTimeCoolDown -= Time.deltaTime;
            image.fillAmount = CalculateFillAmount(_currentTimeCoolDown);
            yield return null;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private float CalculateFillAmount(float time)
    {
        return time / _timeCoolDown;
    }
}
