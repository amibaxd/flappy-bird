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
        if(!GameManager.instance.isGameOver)
            transform.Translate(new Vector2((float)speed * Time.deltaTime * -1, 0));

        speed = GameManager.instance.speed;
    }
}
