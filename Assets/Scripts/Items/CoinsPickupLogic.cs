using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickupLogic : BaseInteractableLogic
{
    [SerializeField] int coinsInside = 50;
    public override void Use()
    {
        FindObjectOfType<PlayerItemsController>().AddCoins(coinsInside);
        Destroy(gameObject);
    }
}
