using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSystem : MonoBehaviour
{
    public static bool IsHidden { get; private set; }
    public static HideSystem Instance;
    GameObject playerRef;
    [SerializeField] float escapeTimer;
    bool canEscape = false;
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
        playerRef = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }
    public void Hide()
    {
        playerRef.SetActive(false);
        StartCoroutine(ChestCoroutine());
        IsHidden = true;
    }
    public void StopHiding()
    {
        IsHidden = false;
        playerRef.SetActive(true);
    }
    IEnumerator ChestCoroutine()
    {
        canEscape = false;
        yield return new WaitForSeconds(escapeTimer);
        canEscape = true;

    }
    private void Update()
    {
        if(IsHidden && Input.GetButtonDown("Interact") && canEscape)
        {
            StopHiding();
        }
    }
}
