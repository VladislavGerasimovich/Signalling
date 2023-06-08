using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _duration = 3f;
    private float _runningTime = 0f;
    private float _minValueOfVolume = 0;
    private float _maxValueOfVolume = 1;

    public void Play()
    {
        StartCoroutine(IncreaseVolume());
    }

    public void Stop()
    {
        StartCoroutine(DecreaseVolume());
    }

    public IEnumerator IncreaseVolume()
    {
        while (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;
            _audio.volume = Mathf.MoveTowards(_minValueOfVolume, _maxValueOfVolume, _runningTime / _duration);
            yield return null;
        }
    }

    public IEnumerator DecreaseVolume()
    {
        while (_runningTime > 0)
        {
            _runningTime -= Time.deltaTime;
            _audio.volume = Mathf.MoveTowards(_minValueOfVolume, _maxValueOfVolume, _runningTime / _duration);
            yield return null;
        }
    }
}
