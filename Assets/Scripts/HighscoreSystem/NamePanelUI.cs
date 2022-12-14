using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NamePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button saveButton;
    void Start()
    {
        inputField = GetComponentInChildren<TMP_InputField>();
        saveButton = GetComponentInChildren<Button>();
        saveButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick(){
        string inputText = inputField.text;
        if(!string.IsNullOrWhiteSpace(inputText)){
            FindObjectOfType<PlayerListController>().OnPlayerSetName(inputText);
        }
    }
}
