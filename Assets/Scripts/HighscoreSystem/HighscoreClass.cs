
using System;
using UnityEngine;
[Serializable]
public class HighscoreClass   
{
    [SerializeField]
    public string HighscoreID;
    [SerializeField]
    public string PlayerID;
    [SerializeField]
    public int Score;

    public HighscoreClass(string playerID, int score){
        HighscoreID = Guid.NewGuid().ToString();
        PlayerID = playerID;
        Score = score;
    }

}