using UnityEditor.Rendering;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
    }
}
