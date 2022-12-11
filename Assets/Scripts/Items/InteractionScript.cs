using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public System.Action OnInteraction;

    bool bCanInteract = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bCanInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            bCanInteract = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && bCanInteract)
        {
            OnInteraction?.Invoke();
        }
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteraction?.Invoke();    
            }
        }
    }*/
}
