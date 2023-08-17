using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private UnityEvent _isIncrease;
    [SerializeField] private UnityEvent _isDecrease;

    private int _healthValue;
    private int _maxHealth;
    private int _minHealth;
    private int _mutableValue;

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
        _text.text = _healthValue.ToString();

        if (_healthValue >= _maxHealth)
        {
            _healthValue = _maxHealth;
            _text.text = _healthValue.ToString();
        }

        _isIncrease.Invoke();
    }

    public void DecreaseHeath()
    {
        _healthValue -= _mutableValue;
        _text.text = _healthValue.ToString();

        if (_healthValue <= _minHealth)
        {
            _healthValue = _minHealth;
            _text.text = _healthValue.ToString();
        }

        _isDecrease.Invoke();
    }
}
