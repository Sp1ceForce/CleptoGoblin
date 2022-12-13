
using System;
using UnityEngine;
[Serializable]
public class PlayerClass   
{
    [SerializeField]
    public string PlayerID;
    
    [SerializeField]
    public string PlayerName;

    public PlayerClass(string name){
        PlayerID = Guid.NewGuid().ToString();
        PlayerName = name;
    }
}