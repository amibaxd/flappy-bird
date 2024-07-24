using UnityEngine;

public class PipePosition : MonoBehaviour
{
    private float topBoundY = 6.7f;
    private float bottomBoundY = 1.3f;
    private float spawnPosX = 18.5f;

    private void OnEnable()
    {
        transform.position = new Vector2(spawnPosX, Random.Range(topBoundY, bottomBoundY));
    }
}
