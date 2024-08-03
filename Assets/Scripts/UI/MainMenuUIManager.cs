using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject mainMenuScreen;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
        settingsButton.onClick.AddListener(SettingsButton);
        quitButton.onClick.AddListener(QuitButton);
    }
    private void Update()
    {
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore");
    }

    void PlayButton()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.isGameOver = false;
            GameManager.instance.isStarting = true;
            GameManager.instance.score = 0;
            GameManager.instance.speed = 5;
        }
        if(UIManager.instance != null)
        {
            UIManager.instance.deathScreen.SetActive(false);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void SettingsButton()
    {
        Debug.Log("Settings Screen Opened");
    }

    void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
