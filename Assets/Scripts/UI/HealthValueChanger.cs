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

    private void Start()
    {
        _initialValue = 0;
        _powerTarget = 0.1f;
        _mutableValue = 0.1f;
        _duration = 0.25f;
    }

    private void Update()
    {
        _power = Mathf.MoveTowards(_initialValue, _powerTarget, _duration * Time.deltaTime);

        if (_isIncrease == true)
        {
            if (_slider.value <= _target)
            {
                _slider.value += _power;
            }
        }
        else if (_isIncrease == false)
        {
            if (_slider.value >= _target)
            {
                _slider.value -= _power;
            }
        }
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
    }
}
