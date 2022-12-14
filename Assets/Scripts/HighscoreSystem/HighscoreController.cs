using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class HighscoreController : MonoBehaviour
{
    [SerializeField] HighscoreCard card;

    private readonly string HighscoresFileDir = @"/CleptoGoblinSaves/";
    private readonly string HighscoresFilesName = @"Highscores.json";
    public List<HighscoreClass> HighscoresList;
    string fileDir;
    PlayerClass activePlayer;
    private void Start() {
        fileDir = Path.Combine(HighscoresFileDir,HighscoresFilesName);               
        CheckIfFileExist();
        LoadHighscoresList();
        activePlayer = FindObjectOfType<PlayerListController>().ActivePlayer;
        if(HighscoresList == null){
                HighscoresList = new List<HighscoreClass>();
        }
        if(activePlayer !=null && !string.IsNullOrWhiteSpace(activePlayer.PlayerName))
        {
            int score = FindObjectOfType<PlayerItemsController>().Coins;
            HighscoreClass newScore = new HighscoreClass(activePlayer.PlayerID,score);
            HighscoresList.Add(newScore);
            SaveHighscoresList();
        
        }
        SpawnCards(); 
    }
    void SpawnCards(){
        var highscoresListSorted = HighscoresList.OrderByDescending(x => x.Score).ToList();
        var playersList = FindObjectOfType<PlayerListController>().PlayersList;
        for(int i = 0; i < 10 && i < highscoresListSorted.Count; i++){
            HighscoreCard newCard = Instantiate(card, transform.position,Quaternion.identity,transform);
            Debug.Log(highscoresListSorted[i].PlayerID);
            string playerName = playersList.FirstOrDefault(x => x.PlayerID == highscoresListSorted[i].PlayerID).PlayerName;
            newCard.Init(playerName,highscoresListSorted[i].Score,i+1);
        }
    }
    void CheckIfFileExist(){
        FileStream fs;
        bool isFileExist = File.Exists(fileDir);
        if(!isFileExist) {
            Directory.CreateDirectory(HighscoresFileDir);
            fs = File.Create(fileDir);
            fs.Close();
        }
    }
    void SaveHighscoresList(){
        Debug.Log(HighscoresList);
        FileStream fs = File.Open(fileDir,FileMode.Create);
        string json = JsonConvert.SerializeObject(HighscoresList,Formatting.Indented);
        StreamWriter sw = new StreamWriter(fs);
        Debug.Log(json);
        sw.Write(json);
        sw.Close();
    }

    void LoadHighscoresList(){
        FileStream fs = File.Open(fileDir,FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string jsonStr = sr.ReadToEnd();
        HighscoresList = JsonConvert.DeserializeObject<List<HighscoreClass>>(jsonStr);
        sr.Close();
    }
   /*  public void OnPlayerSetName(string Name){
        PlayerClass playerClass = HighscoresList.FirstOrDefault(x => x.PlayerName.ToLower() == Name.ToLower());
        if (playerClass != null){
            ActivePlayer = playerClass; 
        }
        else{
            var newPlayer = new PlayerClass(Name);
            HighscoresList.Add(newPlayer);
            SaveHighscoresList();
        }
    } */
}
