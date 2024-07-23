using UnityEngine;

public class PipePosition : MonoBehaviour
{
    private float topBoundY = 5.1f;
    private float bottomBoundY = -3.8f;
    private float spawnPosX = 18.5f;

    private void OnEnable()
    {
        transform.position = new Vector2(spawnPosX, Random.Range(topBoundY, bottomBoundY));
        GetComponent<MoveLeft>().enabled = true;
    }
}
