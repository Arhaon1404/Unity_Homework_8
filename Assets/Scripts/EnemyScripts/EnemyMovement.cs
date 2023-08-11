using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private Transform[] _points;
    private int _currentPoint;
    private bool _isleft = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0;i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position,target.position,_speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }

            if (_isleft == true)
            {
                _isleft = false;
                _spriteRenderer.flipX = true;
            }
            else
            {
                _isleft = true;
                _spriteRenderer.flipX = false;
            }
        }
    }
}
