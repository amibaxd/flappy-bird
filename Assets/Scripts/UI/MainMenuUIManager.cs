using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject mainMenuScreen;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
        settingsButton.onClick.AddListener(SettingsButton);
        quitButton.onClick.AddListener(QuitButton);
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
