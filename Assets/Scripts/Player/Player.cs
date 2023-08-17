using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private UnityEvent<float> _isChange;

    private int _healthValue;
    private int _maxHealth;
    private int _minHealth;
    private int _mutableValue;
    private float _floatHealthValue;

    private void Start()
    {
        _healthValue = 0;
        _maxHealth = 100;
        _minHealth = 0;
        _mutableValue = 10;
        _text.text = _healthValue.ToString();
    }

    public void IncreaseHeath()
    {
        _healthValue += _mutableValue;

        if (_healthValue >= _maxHealth)
        {
            _healthValue = _maxHealth;
        }

        _text.text = _healthValue.ToString();

        _floatHealthValue = Convert.ToSingle(_healthValue) / 100;

        _isChange.Invoke(_floatHealthValue);
    }

    public void DecreaseHeath()
    {
        _healthValue -= _mutableValue;

        if (_healthValue <= _minHealth)
        {
            _healthValue = _minHealth;
        }

        _text.text = _healthValue.ToString();

        _floatHealthValue = Convert.ToSingle(_healthValue) / 100;

        _isChange.Invoke(_floatHealthValue);
    }
}
