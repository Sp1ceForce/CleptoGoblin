using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSystem : MonoBehaviour
{
    public static bool IsHidden { get; private set; }
    public static HideSystem Instance;
    GameObject playerRef;
    private void Start()
    {
        if(HideSystem.Instance == null)
        {
            HideSystem.Instance = this;
        }
        else
        {
            Debug.LogError("More than one instance of HideSystem!");
        }
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    public void Hide()
    {
        playerRef.SetActive(false);
        IsHidden = true;
    }
    public void StopHiding()
    {
        IsHidden = false;
        playerRef.SetActive(true);
    }
    private void Update()
    {
        if(IsHidden && Input.GetButtonDown("Interact"))
        {
            StopHiding();
        }
    }
}
