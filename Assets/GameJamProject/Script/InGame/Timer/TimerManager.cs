using GameJamProject.System;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour, IPause
{
    [SerializeField] private Text _timerText;
    [SerializeField] private float _limitTime;
    private float _remainingTime;
    private bool _isPause;

    public void Start()
    {
        if (_timerText is not null)
        {
            _remainingTime = _limitTime;
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogError("TimerTextが設定されていません");
        }
#endif
    }

    private void Update()
    {
        if (!_isPause && _remainingTime > 0 && _timerText)
        {
            _timerText.text = $"残り時間 : {_remainingTime.ToString("F2")}秒";
            _remainingTime -= Time.deltaTime;
        }
        else if (_remainingTime < 0)
        {
            _timerText.text = $"時間切れ";
        }
    }

    public void Pause()
    {
        _isPause = true;
    }

    public void Resume()
    {
        _isPause = false;
    }
}