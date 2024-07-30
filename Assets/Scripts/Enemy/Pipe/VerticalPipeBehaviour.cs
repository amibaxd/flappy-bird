using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class VerticalPipeBehaviour : PipeBehaviour
{
    [SerializeField] private float spawnPointY;
    [SerializeField] private float lowerBoundY;

    [SerializeField] private float verticalSpeed;

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);

            if (transform.position.y < lowerBoundY)
                transform.position = new Vector3(transform.position.x, spawnPointY, transform.position.z);
        }
    }
}
