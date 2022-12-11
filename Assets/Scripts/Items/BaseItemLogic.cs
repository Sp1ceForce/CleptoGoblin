using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionScript))]
public abstract class BaseItemLogic : MonoBehaviour
{
    public virtual void Start()
    {
        GetComponent<InteractionScript>().OnInteraction += Use;
    }
    public abstract void Use();
}
