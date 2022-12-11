using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractionLogic : BaseInteractableLogic
{
    [SerializeField] int keysInside = 1;
    public override void Use()
    {
        FindObjectOfType<PlayerItemsController>().AddKey(keysInside);
    }
}
