using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _duration = 3f;
    private float _runningTime = 0f;
    private float _startPosition = 0;
    private float _endPosition = 1;
    private Coroutine _changeVolumeJob;

    public void Play()
    {
        _changeVolumeJob = StartCoroutine(ChangeVolume(_startPosition, _endPosition));
    }

    public void Stop()
    {
        StartCoroutine(ChangeVolume(_endPosition, _startPosition));
    }

    public IEnumerator ChangeVolume(float startPosition, float endPosition)
    {
        _runningTime = 0f;

        while (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            _audio.volume = Mathf.MoveTowards(startPosition, endPosition, _runningTime / _duration);
            yield return null;
        }

        StopCoroutine(_changeVolumeJob);
    }
}
