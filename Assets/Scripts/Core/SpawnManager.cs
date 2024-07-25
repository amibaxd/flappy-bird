using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private int numberOfNormalPipes;
    [SerializeField] private int numberOfShooterPipes;

    [SerializeField] private float spawnDelay;
    private float spawnTimer;


    private void Update()
    {
        if (spawnTimer >= spawnDelay && !GameManager.instance.isGameOver)
        {
            pipes[FindPipe()].SetActive(true);
            spawnTimer = 0;
        }
        else
            spawnTimer += Time.deltaTime;

    }

    int FindPipe()
    {
        var inactivePipes = pipes.Where(pipe => !pipe.activeInHierarchy).ToArray();
        int randomPipeIndex = Random.Range(0, inactivePipes.Length);

        return randomPipeIndex;
    }


}
