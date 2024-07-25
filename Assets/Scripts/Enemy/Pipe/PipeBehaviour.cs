using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    [SerializeField] private float topBoundY;
    [SerializeField] private float bottomBoundY;
    [SerializeField] private float spawnPosX; 

    private void OnEnable()
    {
        transform.position = new Vector2(spawnPosX, Random.Range(topBoundY, bottomBoundY));
    }

    public void OnPlayerCollision()
    {
        Debug.Log("Collided with Player");
    }
}
