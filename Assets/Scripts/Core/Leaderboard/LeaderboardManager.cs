using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;

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

    public Leaderboard leaderboard = new Leaderboard();
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
    }

    public void AddHighScore(string _name, int _score)
    {
        Player player = new Player();
        player.name = _name;
        player.score = _score;

        bool playerExists = false;

        // Check if player already exists in the leaderboard
        foreach (var item in leaderboard.playerList)
        {
            if (item.name == _name)
            {
                playerExists = true;
                // If the new score is higher, update the score
                if (_score > item.score)
                {
                    item.score = _score;
                }
                break;
            }
        }

        // If the player doesn't exist and the leaderboard has less than 10 players, add the player
        if (!playerExists && leaderboard.playerList.Count < 10)
        {
            leaderboard.playerList.Add(player);
        }
        else if (!playerExists && leaderboard.playerList.Count == 10)
        {
            // If the player doesn't exist and the leaderboard is full, check if the new score is high enough to enter the leaderboard
            if (_score > leaderboard.playerList[9].score) // Compare with the lowest score on the leaderboard
            {
                // Replace the lowest score with the new player
                leaderboard.playerList[9] = player;
            }
        }

        // Sort the leaderboard
        leaderboard.playerList.Sort((x, y) => y.score.CompareTo(x.score));

        // Save the leaderboard
        string leaderboardJson = JsonUtility.ToJson(leaderboard);
        PlayerPrefs.SetString("leaderboardData", leaderboardJson);
        PlayerPrefs.Save();
    }

}
