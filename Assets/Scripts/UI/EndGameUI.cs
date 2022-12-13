using UnityEngine;
using TMPro;
public class EndGameUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText; 
    PlayerItemsController itemsController;
    public void Start(){
        itemsController = FindObjectOfType<PlayerItemsController>();
        scoreText.text = itemsController.Coins.ToString();
    }
}