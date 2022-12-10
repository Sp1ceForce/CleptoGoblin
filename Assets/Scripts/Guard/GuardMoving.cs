using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMoving : MonoBehaviour
{
    [SerializeField] List<GameObject> waypoints;
    int currentIndex = 0;

    NavMeshAgent navAgent;

    GameObject playerRef;
    bool isLookingForPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        GetComponent<GuardFOV>().OnPlayerDetected += OnPlayerDetected;
    }
    
    void OnPlayerDetected(GameObject playerObject)
    {
        isLookingForPlayer=true;
        playerRef = playerObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLookingForPlayer)
        {
            navAgent.SetDestination(playerRef.transform.position);
        }
        else if (!navAgent.pathPending)
        {
            if (waypoints.Count == 0) return;
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    if (currentIndex + 1 >= waypoints.Count) currentIndex = 0;
                    else currentIndex++;
                    navAgent.SetDestination(waypoints[currentIndex].transform.position);
                    
                }
            }
        }
    }
}
