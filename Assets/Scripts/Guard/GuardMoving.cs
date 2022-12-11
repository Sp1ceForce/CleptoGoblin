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

    [SerializeField] float waitingTime = 2f;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        GetComponent<GuardFOV>().OnPlayerDetected += OnPlayerDetected;
    }
    
    void OnPlayerDetected(GameObject playerObject)
    {
        isLookingForPlayer=true;
        navAgent.isStopped = false;
        playerRef = playerObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLookingForPlayer)
        {
            navAgent.SetDestination(playerRef.transform.position);
        }
        else if (!navAgent.pathPending && !navAgent.isStopped)
        {
            if (waypoints.Count == 0) return;
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    navAgent.isStopped = true;
                    StartCoroutine(WaitRoutine());
                }
            }
        }
    }
    IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(waitingTime);
        SetNextDestination();
    }

    private void SetNextDestination()
    {
        if (waypoints.Count == 0) return;
        if (currentIndex + 1 >= waypoints.Count) currentIndex = 0;
        else currentIndex++;
        navAgent.isStopped = false;
        navAgent.SetDestination(waypoints[currentIndex].transform.position);
    }
}
