using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

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
        if (_healthValue < _maxHealth)
        {
            _healthValue += _mutableValue;
            _text.text = _healthValue.ToString();
        }
    }

    public void DecreaseHeath()
    {
        if (_healthValue > _minHealth)
        {
            _healthValue -= _mutableValue;
            _text.text = _healthValue.ToString();
        }
    }
}
