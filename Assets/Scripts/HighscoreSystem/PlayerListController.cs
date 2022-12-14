using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
public class PlayerListController : MonoBehaviour {
    private readonly string PlayersFileDir = @"/CleptoGoblinSaves/";
    private readonly string PlayerFileName = @"Players.json";
    public PlayerClass ActivePlayer;
    public List<PlayerClass> PlayersList;
    bool isConfigured = false;
    string fileDir;
    private void Start() {
        DontDestroyOnLoad(gameObject);
        if(!isConfigured){
            fileDir = Path.Combine(PlayersFileDir,PlayerFileName);       
            CheckIfPlayerListExists();
            LoadPlayerList();
            if(PlayersList == null) PlayersList = new List<PlayerClass>();
            isConfigured = true;
        }

    }

    void CheckIfPlayerListExists(){
        FileStream fs;
        bool isFileExist = File.Exists(fileDir);
        if(!isFileExist) {
            Directory.CreateDirectory(PlayersFileDir);
            fs = File.Create(fileDir);
            fs.Close();
        }
    }
    void SavePlayerList(){

        FileStream fs = File.Open(fileDir,FileMode.Create);
        string json = JsonConvert.SerializeObject(PlayersList,Formatting.Indented);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(json);
        sw.Close();
    }

    void LoadPlayerList(){
        FileStream fs = File.Open(fileDir,FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string jsonStr = sr.ReadToEnd();
        PlayersList = JsonConvert.DeserializeObject<List<PlayerClass>>(jsonStr);
        sr.Close();
    }
    public void OnPlayerSetName(string Name){
        PlayerClass playerClass = PlayersList.FirstOrDefault(x => x.PlayerName.ToLower() == Name.ToLower());
        if (playerClass != null){
            ActivePlayer = playerClass; 
        }
        else{
            var newPlayer = new PlayerClass(Name);
            PlayersList.Add(newPlayer);
            ActivePlayer = newPlayer;
            SavePlayerList();
        }
    }
}