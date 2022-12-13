using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
public class PlayerListController : MonoBehaviour {
    private readonly string PlayersFileDir = @"/Saves/Players.json";
    public PlayerClass ActivePlayer;
    public List<PlayerClass> PlayersList;

    private void Start() {
        PlayerClass[] players = {
            new PlayerClass("AbobaTech"),new PlayerClass("Pepega"),new PlayerClass("Progger"),new PlayerClass("Eboba"),new PlayerClass("Akshan")
        };
        PlayersList.AddRange(players);
        string json = JsonConvert.SerializeObject(PlayersList,Formatting.Indented);
        Debug.Log(json);
        if(File.Exists(PlayersFileDir)){
            Debug.Log("Exists");
        }
    
    }

    public void OnPlayerSetName(string Name){
        PlayerClass playerClass = PlayersList.FirstOrDefault(x => x.PlayerName.ToLower() == Name.ToLower());
        if (playerClass != null){
            ActivePlayer = playerClass; 
        }
        else{

        }
    }
}