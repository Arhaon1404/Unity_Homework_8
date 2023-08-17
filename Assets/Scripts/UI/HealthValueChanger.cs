using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthValueChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    private float _duration;
    private float _initialValue;
    private float _powerTarget;
    private float _power;
    private float _mutableValue;
    private float _target;

    private bool _isIncrease = false;

    private Coroutine _changeHealthCoroutine;
    [SerializeField] private float _secondsPeriod;
    private bool _isDone;

    private void Start()
    {
        _initialValue = 0;
        _powerTarget = 0.2f;
        _mutableValue = 0.1f;
        _duration = 0.25f;
        _secondsPeriod = 0.05f;
        _isDone = true;
    }

    private void Update()
    {
        _power = Mathf.MoveTowards(_initialValue, _powerTarget, _duration * Time.deltaTime);
    }

    public void IncreaseHeath()
    {
        if (_target < 1)
        {
            _isIncrease = true;
            _target += _mutableValue;
        }
        else if (_target > 1)
        {
            _target = 1;
        }

        RunCoroutine();
    }

    public void DecreaseHeath()
    {
        if (_target > 0)
        {
            _isIncrease = false;
            _target -= _mutableValue;
        }
        else if(_target < 0)
        {
            _target = 0;
        }

        RunCoroutine();
    }

    private IEnumerator ChangeHealth()
    {
        while (_isDone == false)
        {
            yield return new WaitForSeconds(_secondsPeriod);

            if (_isIncrease == true)
            {
                if (_slider.value <= _target)
                {
                    _slider.value += _power;
                }
                else if (_slider.value >= _target)
                {
                    _isDone = true;
                }
            }
            else if (_isIncrease == false)
            {
                if (_slider.value >= _target)
                {
                    _slider.value -= _power;
                }
                else if (_slider.value <= _target)
                { 
                    _isDone = true;
                }
            }
        }
    }

    private void RunCoroutine()
    {
        if (_changeHealthCoroutine != null & _isDone == true)
        {
            StopCoroutine(_changeHealthCoroutine);
        }

        if (_isDone == true)
        {
            _isDone = false;
            _changeHealthCoroutine = StartCoroutine(ChangeHealth());
        }
    }

}
