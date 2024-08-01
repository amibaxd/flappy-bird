using System;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public double speed;
    public double baseSpeed;
    public double endSpeed;


    private void Awake()
    {
        speed = 5;
        baseSpeed = 15;
        endSpeed = 20;
    }

    private void Update()
    {
        speed = GameManager.instance.speed;

        if (GameManager.instance.isStarting)
        {
            if(gameObject.tag == "Background" && GameManager.instance.isStarting)
            {
                transform.Translate(new Vector2((float)speed * Time.deltaTime * -1, 0));
                return;
            }
        }

        if(!GameManager.instance.isGameOver)
            transform.Translate(new Vector2((float)speed * Time.deltaTime * -1, 0));

        
    }
}
