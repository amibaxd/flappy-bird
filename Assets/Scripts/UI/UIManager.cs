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
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI startText;

    [Header("Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button backToMenuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button deathBackToMenuButton;

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

        deathBackToMenuButton.onClick.AddListener(BackToMenuButton);
    }
    private void Update()
    {
        scoreText.text = "Score : " + GameManager.instance.score;


        if(SceneManager.GetActiveScene().name == "MainGame")
        {
            if (MainMenuUIManager.instance != null)
            {
                if (!MainMenuUIManager.instance.mainMenuScreen.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!deathScreen.activeInHierarchy)
                        ResumeButton();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!deathScreen.activeInHierarchy)
                        ResumeButton();
                }
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartButton();
            }

            if (deathScreen.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
                BackToMenuButton();

            if (!GameManager.instance.isStarting)
                startText.enabled = false;
        }
        
    }
    

    void ResumeButton()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        pauseScreen.SetActive(Time.timeScale == 1 ? false : true);

        if (GameManager.instance.isStarting && Time.timeScale == 0)
            startText.enabled = false;
        else if (GameManager.instance.isStarting && Time.timeScale == 1)
            startText.enabled = true; 
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.isGameOver = false;
        GameManager.instance.score = 0;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        scoreText.enabled = false;

        if (MainMenuUIManager.instance != null)
        {
            MainMenuUIManager.instance.mainMenuScreen.SetActive(true);
            MainMenuUIManager.instance.nameInputField.text = "";
        }
            
    }

    void RestartButton()
    {
        GameManager.instance.isGameOver = false;
        GameManager.instance.isStarting = true;
        GameManager.instance.score = 0;
        deathScreen.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.speed = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
