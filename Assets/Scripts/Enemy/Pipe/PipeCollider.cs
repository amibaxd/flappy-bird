using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    private PipeBehaviour pipeBehaviour;

    private void OnEnable()
    {
        pipeBehaviour = GetComponentInParent<PipeBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pipeBehaviour.OnPlayerCollision();
        }
    }
}
