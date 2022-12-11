using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPromptScript : MonoBehaviour
{
    [SerializeField] GameObject Prompt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Prompt.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Prompt.SetActive(false);
        }
    }
}
