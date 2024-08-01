using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public double speed;

    public bool isGameOver;
    public int score;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        UIManager.instance.pauseScreen.SetActive(false);
        UIManager.instance.deathScreen.SetActive(false);

        speed = 5;
        isGameOver = false;
        score = 0;
    }

    private void Update()
    {

    }
    public void AddScore(int _score)
    {
        score += _score;

        MoveLeft[] moveLeftScripts = FindObjectsOfType<MoveLeft>();

        foreach (MoveLeft moveLeft in moveLeftScripts)
        {
            if (score <= 50)
            {
                // Linear increase from 5 to 15 over 50 iterations
                speed = 5 + (score - 1) * (15 - 5) / 49.0; // Linearly interpolate from 5 to 15
            }
            else
            {
                // Logarithmic increase from 15 to 20 over the next 50 iterations
                int adjustedI = score - 50; // Adjust index for the logarithmic phase
                speed = moveLeft.baseSpeed + (moveLeft.endSpeed - moveLeft.baseSpeed) * (Math.Log(adjustedI + 1) / Math.Log(50));
            }
        }
    }
}
