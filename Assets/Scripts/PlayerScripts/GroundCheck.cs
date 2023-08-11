using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _onGround.Invoke();
        }
    }
}
