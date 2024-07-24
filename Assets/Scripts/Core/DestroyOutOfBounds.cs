using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float leftBoundX;

    private void Update()
    {
        if (gameObject.tag != "Background")
        {
            if (transform.position.x <= leftBoundX)
            {
                gameObject.SetActive(false);
            }

        }
    }
}
