using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickupLogic : BaseInteractableLogic
{
    [SerializeField] int coinsInside = 50;
    [SerializeField] GameObject Help;

    public override void Use()
    {
        Camera.main.SendMessage("coinPlay");
        FindObjectOfType<PlayerItemsController>().AddCoins(coinsInside);
        Destroy(gameObject);
    }

}
