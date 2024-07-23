using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flapStrength;

    private float rotationAmount;
    [SerializeField] private float rotationValue;

    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        rotationAmount = -90;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, flapStrength);
            rotationAmount = -90;
        }
        if (rotationAmount <= -180)
            rotationAmount = -90;
        else
            rotationAmount -= rotationValue;

        transform.rotation = Quaternion.Euler(0, 0, rotationAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rotationValue = 0;
            GetComponent<PlayerController>().enabled = false;
        }
    }
}
