using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    [SerializeField] protected float topBoundY;
    [SerializeField] protected float bottomBoundY;
    [SerializeField] protected float spawnPosX; 

    private void OnEnable()
    {
        float randomY = Random.Range(bottomBoundY, topBoundY);
        transform.position = new Vector2(spawnPosX, randomY);
    }

    public void OnPlayerCollision()
    {
        GameManager.instance.EndGame();
    }
}
