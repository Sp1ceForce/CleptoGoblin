using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookGrab : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distancePickUp = 1f;
    private GameObject grabItem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Item") return;
        if (other == null) return;
        grabItem = other.gameObject;
        grabItem.transform.SetParent(this.gameObject.transform);
        Debug.Log(other.name);
        this.transform.parent.gameObject.SendMessage("ReturnHook");
    }
    private void Update()
    {
        if (grabItem != null)
        {
            if (Vector3.Distance(grabItem.transform.position, player.position) <= distancePickUp)
            {
                Destroy(grabItem);
            }
        }
    }
}
