using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button backToMenuButton;
    [SerializeField] private Button restartButton;

    [Header("Screens")]
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject deathScreen;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        resumeButton.onClick.AddListener(ResumeButton);
        backToMenuButton.onClick.AddListener(BackToMenuButton);
        restartButton.onClick.AddListener(RestartButton);
    }
    private void Update()
    {
        scoreText.text = "Score : " + GameManager.instance.score;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeButton();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartButton();
        }
    }

    void ResumeButton()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        pauseScreen.SetActive(Time.timeScale == 1 ? false : true);
    }

    void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.isGameOver = false;
        GameManager.instance.score = 0;
        Time.timeScale = 1;
    }

    void RestartButton()
    {
        GameManager.instance.isGameOver = false;
        GameManager.instance.score = 0;
        deathScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
