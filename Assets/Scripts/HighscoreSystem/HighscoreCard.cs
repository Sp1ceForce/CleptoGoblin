using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighscoreCard : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    private readonly string formatterString = "{0} - {1} - {2}";
    public void Init(string PlayerName,int PlayerScore, int place){
        var formattedStr = string.Format(formatterString,place,PlayerName,PlayerScore);
        Debug.Log(formattedStr);
        textComponent.text = formattedStr;
    }
}
