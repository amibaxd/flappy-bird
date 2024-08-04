using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pipes;

    [SerializeField] private float spawnDelay;
    private float spawnTimer = Mathf.Infinity;


    private void Update()
    {
        if (spawnTimer >= spawnDelay && !GameManager.instance.isGameOver && !GameManager.instance.isStarting)
        {
            FindPipe().SetActive(true);
            spawnTimer = 0;
        }
        else
            spawnTimer += Time.deltaTime;

        if (GameManager.instance.score == 20)
            spawnDelay = 1.4f;
        else if (GameManager.instance.score == 40)
            spawnDelay = 1.3f;
        else if (GameManager.instance.score == 70)
            spawnDelay = 1.2f;

    }

    GameObject FindPipe()
    {
        var inactivePipes = pipes.Where(pipe => !pipe.activeInHierarchy).ToArray();
        int randomPipeIndex = Random.Range(0, inactivePipes.Length);

        return inactivePipes[randomPipeIndex];
    }


}
