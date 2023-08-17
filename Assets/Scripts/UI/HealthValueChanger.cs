using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthValueChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _duration;
    private float _powerInitialValue;
    private float _powerTarget;
    private float _power;
    private float _target;

    private Coroutine _changeValueCoroutine;
    private float _secondsPeriod;
    private bool _isDone;

    private void Start()
    {
        _powerInitialValue = 0;
        _powerTarget = 0.1f;
        _duration = 0.5f;
        _secondsPeriod = 0.01f;
        _isDone = true;
    }

    public void ChangeTargetValue(float target)
    {
        _target = target;

        RunCoroutine();
    }

    private IEnumerator ChangeSliderValue()
    {
        while (_isDone == false)
        {
            yield return new WaitForSeconds(_secondsPeriod);

            _power = Mathf.MoveTowards(_powerInitialValue, _powerTarget, _duration * Time.deltaTime);

            if (_slider.value < _target)
            {
                _slider.value += _power;

                if (_slider.value >= _target)
                {
                    _isDone = true;
                }
            }
            else if (_slider.value > _target)
            {
                _slider.value -= _power;
                
                if (_slider.value <= _target)
                { 
                    _isDone = true;
                }
            }
        }
    }

    private void RunCoroutine()
    {
        if (_changeValueCoroutine != null & _isDone == true)
        {
            StopCoroutine(_changeValueCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _changeValueCoroutine = StartCoroutine(ChangeSliderValue());
        }
    }
}
