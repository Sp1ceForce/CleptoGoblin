using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickupLogic : BaseInteractableLogic
{
    [SerializeField] int coinsInside = 50;
    [SerializeField] AudioSource CoinPick;
    public override void Use()
    {
        CoinPick.Play();
        FindObjectOfType<PlayerItemsController>().AddCoins(coinsInside);
        Destroy(gameObject);
    }
}
