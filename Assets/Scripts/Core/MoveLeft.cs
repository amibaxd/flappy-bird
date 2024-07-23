using UnityEditor.Rendering;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftBoundX;

    private void Update()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if(gameObject.tag != "Background")
        {
            if (transform.position.x <= leftBoundX)
            {
                gameObject.SetActive(false);
                GetComponent<MoveLeft>().enabled = false;
            }
                
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {

        }
    }
}
