using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System;

public class MainMenuUIManager : MonoBehaviour
{

    public static MainMenuUIManager instance;

    public string playerName;

    [Header("Screens")]
    [SerializeField] public GameObject mainMenuScreen;
    [SerializeField] private GameObject leaderboardScreen;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button backToMenuButton;
    [SerializeField] private Button clearRecordsButton;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI noRecordsText;
    [SerializeField] private TextMeshProUGUI enterNameText;

    [Header("Input Fields")]
    [SerializeField] public TMP_InputField nameInputField;

    [Header("Leaderboard Text List")]
    [SerializeField] private TextMeshProUGUI[] highscoreTexts;

    [Serializable]
    public class Player
    {
        public string name;
        public int score;
    }

    [Serializable]
    public class Leaderboard
    {
        public List<Player> playerList = new List<Player>();
    }

    private Leaderboard leaderboard;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        playButton.onClick.AddListener(PlayButton);
        leaderboardButton.onClick.AddListener(LeaderboardButton);
        quitButton.onClick.AddListener(QuitButton);

        backToMenuButton.onClick.AddListener(BackToMenuButton);
        clearRecordsButton.onClick.AddListener(ClearRecordsFromLeaderboard);

        mainMenuScreen.SetActive(true);
        leaderboardScreen.SetActive(false);
        noRecordsText.enabled = false;
        nameInputField.text = "";

        enterNameText.enabled = false;
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Return))
                PlayButton();

            if (leaderboardScreen.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
                BackToMenuButton();
        }
        
    }

    void PlayButton()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.isGameOver = false;
                GameManager.instance.isStarting = true;
                GameManager.instance.score = 0;
                GameManager.instance.speed = 5;
            }
            if (UIManager.instance != null)
            {
                UIManager.instance.scoreText.enabled = true;
                UIManager.instance.deathScreen.SetActive(false);
            }

            Time.timeScale = 1;
            playerName = nameInputField.text;
            mainMenuScreen.SetActive(false);

            SceneManager.LoadScene(1);
        }
        else
        {
            StartCoroutine(EnterNameDisappearCountdown());
        }
    }

    IEnumerator EnterNameDisappearCountdown()
    {

        enterNameText.enabled = true;
        yield return new WaitForSeconds(1);
        enterNameText.enabled = false;
    }

    public void LeaderboardButton()
    {
        mainMenuScreen.SetActive(false);
        leaderboardScreen.SetActive(true);

        string leaderboardString = PlayerPrefs.GetString("leaderboardData");
        if(leaderboardString != "")
        {
            leaderboard = JsonUtility.FromJson<Leaderboard>(leaderboardString);
            if (leaderboard != null)
            {
                if (leaderboard.playerList.Count == 0)
                {
                    noRecordsText.enabled = true;
                }
                else
                {
                    for (int i = 0; i < leaderboard.playerList.Count; i++)
                    {
                        if (leaderboard.playerList[i] != null)
                        {
                            highscoreTexts[i].text = leaderboard.playerList[i].name + " : " + leaderboard.playerList[i].score;
                        }
                    }
                }
            }
            else
            {
                noRecordsText.enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < highscoreTexts.Length; i++)
            {
                if (highscoreTexts[i] != null)
                {
                    highscoreTexts[i].text = "";
                }
            }
            noRecordsText.enabled = true;
        }
        
    }

    void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
        leaderboardScreen.SetActive(false);
        noRecordsText.enabled = false;
        mainMenuScreen.SetActive(true);
        nameInputField.text = "";
    }

    public void ClearRecordsFromLeaderboard()
    {
        PlayerPrefs.DeleteKey("leaderboardData");
        LeaderboardButton();
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
