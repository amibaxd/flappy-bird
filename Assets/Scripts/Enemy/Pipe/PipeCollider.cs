using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    private PipeBehaviour pipeBehaviour;

    private void Awake()
    {
        pipeBehaviour = GetComponentInParent<PipeBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pipeBehaviour.OnPlayerCollision();
    }
}
