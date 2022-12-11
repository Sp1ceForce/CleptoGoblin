using UnityEngine;

[RequireComponent(typeof(InteractionScript))]
public abstract class BaseInteractableLogic : MonoBehaviour
{
    public virtual void Start()
    {
        GetComponent<InteractionScript>().OnInteraction += Use;
    }
    public abstract void Use();
}
