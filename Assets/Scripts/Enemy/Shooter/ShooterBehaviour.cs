using UnityEngine;

public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject[] arrows;

    [SerializeField] private float attackDelay;
    private float attackTimer = Mathf.Infinity;

    private GameObject player;
    [SerializeField] private float rightBoundX;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (attackTimer >= attackDelay && transform.position.x > player.transform.position.x && transform.position.x < rightBoundX)
        {
            arrows[FindArrow()].SetActive(true);

            attackTimer = 0;
        }
        else
            attackTimer += Time.deltaTime;
    }

    int FindArrow()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

}
