using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flapStrength;

    private float rotationAmount;
    [SerializeField] private float rotationValue;

    [SerializeField] private float upperBoundY;

    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        rotationAmount = -90;
    }

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.velocity = new Vector2(0, flapStrength);
                rotationAmount = -45;
            }
            if (rotationAmount <= -180)
                rotationAmount = -45;
            else
                rotationAmount -= rotationValue * Time.deltaTime * 500;

            transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
        }

        if(transform.position.y >= upperBoundY)
        {
            transform.position = new Vector2(transform.position.x, upperBoundY);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Pipe")
        {
            rotationValue = 0;
            GetComponent<PlayerController>().enabled = false;
            GameManager.instance.isGameOver = true;
            UIManager.instance.deathScreen.SetActive(true);
        }
    }
}
