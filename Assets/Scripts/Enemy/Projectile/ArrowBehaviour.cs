using UnityEngine;
using UnityEngine.Rendering;

public class ArrowBehaviour : MonoBehaviour
{
    private GameObject player;
    private GameObject firePoint;
    private Rigidbody2D arrowRb;

    [SerializeField] private float speed;

    private PlayerController playerController;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnEnable()
    {
        player = GameObject.Find("Player");
        arrowRb = GetComponent<Rigidbody2D>();
        firePoint = transform.parent.gameObject;

        transform.position = firePoint.transform.position;
        Vector2 direction = player.transform.position - firePoint.transform.position;
        arrowRb.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);

            playerController.KillPlayer();
        }
        else if(collision.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
