using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTxt;

    private float _elapsedTime;
    private TimeSpan _timePlaying;
    private bool _isCount;
    
    private void Start()
    {
        _elapsedTime = 0f;
        _isCount = true;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (_isCount)
        {
            _elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            string timePlaying = _timePlaying.ToString("hh':'mm':'ss");
            timeTxt.text = timePlaying;
            yield return null;
        }
    }

    public void StopCount() => _isCount = false;
    public float GetElapsedTime => _elapsedTime;
}
