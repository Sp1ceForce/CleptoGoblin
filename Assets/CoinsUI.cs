using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsUI : MonoBehaviour
{
    [SerializeField] TMP_Text CoinsText;
    [SerializeField] TMP_Text KeysText;

    PlayerItemsController playerItemsController;
    private void Start()
    {
        playerItemsController = FindObjectOfType<PlayerItemsController>();
        playerItemsController.OnItemsChange+= UpdateText;
    }
    void UpdateText()
    {
        CoinsText.text = playerItemsController.Coins.ToString();
        KeysText.text = playerItemsController.Keys.ToString();
    }

}
