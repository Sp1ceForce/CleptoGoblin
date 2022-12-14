using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractionLogic : BaseInteractableLogic
{
    [SerializeField] int keysInside = 1;
    [SerializeField] GameObject Help;
    public override void Use()
    {
        Camera.main.SendMessage("keyPlay");
        FindObjectOfType<PlayerItemsController>().AddKey(keysInside);
        Destroy(gameObject);
    }
}
