using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private float spawnDelay;
    private float spawnTimer;


    private void Update()
    {
        if (spawnTimer >= spawnDelay)
        {
            pipes[FindPipe()].SetActive(true);
            spawnTimer = 0;
        }
        else
            spawnTimer += Time.deltaTime;
        
    }

    int FindPipe()
    {
        for (int i=0; i<pipes.Length; i++)
        {
            if (!pipes[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

    
}
