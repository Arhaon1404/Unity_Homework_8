using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemDelete : MonoBehaviour
{
    private Transform _topParent;
    private Transform _point;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Destroy(this.gameObject);

            _topParent = transform.root;
            _point = transform.parent;

            _topParent.BroadcastMessage("RunCoroutine", _point);
        }
    }
}
