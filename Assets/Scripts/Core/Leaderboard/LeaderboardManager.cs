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

        if (leaderboard.playerList.Count < 10)
        {
            leaderboard.playerList.Add(player);
        }
        else if(leaderboard.playerList.Count == 10)
        {
            int index = leaderboard.playerList.FindIndex(x => x.score < _score);

            if(index != -1)
            {
                for (int i=8; i>=index; i--)
                {
                    leaderboard.playerList[i + 1] = leaderboard.playerList[i];
                }
                leaderboard.playerList[index] = player;
            }
        }

        leaderboard.playerList.Sort((x, y) => y.score.CompareTo(x.score));

        string leaderboardJson = JsonUtility.ToJson(leaderboard);
        PlayerPrefs.SetString("leaderboardData", leaderboardJson);
    }
}
