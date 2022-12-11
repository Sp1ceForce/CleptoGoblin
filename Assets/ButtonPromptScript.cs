using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPromptScript : MonoBehaviour
{
    [SerializeField] GameObject Prompt;

    private void Start()
    {
        Prompt.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Prompt.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Prompt.SetActive(false);

    }
}
