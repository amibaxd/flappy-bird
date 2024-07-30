using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver { get; private set; }
    public int score { get; private set; }

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

        isGameOver = false;
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isGameOver = false;
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void StartGame()
    {
        isGameOver = false;
    }

    public void EndGame()
    {
        isGameOver = true;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }
}
