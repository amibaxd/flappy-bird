using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatWidth;

    private void Awake()
    {
        startPos = transform.position;
        repeatWidth = (GetComponent<BoxCollider2D>().size.x / 2) * transform.localScale.x;
    }

    private void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
            transform.position = startPos;
    }
}
