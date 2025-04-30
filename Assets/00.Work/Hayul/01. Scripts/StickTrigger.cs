using NUnit.Framework;
using System;
using UnityEngine;

public class StickTrigger : MonoBehaviour
{
    [SerializeField] private StickDrag stickDrag;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PosIndex posindex;
        if (collision.TryGetComponent(out posindex))
        {
            stickDrag.OnCheckPointTrigger(posindex.posIndex);
        }

    }
}
