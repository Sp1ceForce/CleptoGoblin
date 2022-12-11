using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public System.Action OnInteraction;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteraction?.Invoke();    
            }
        }
    }
}
