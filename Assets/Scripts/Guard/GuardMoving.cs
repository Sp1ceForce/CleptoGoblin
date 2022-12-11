using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMoving : MonoBehaviour
{
    [SerializeField] List<GameObject> waypoints;
    public System.Action OnPlayerLost;
    int currentIndex = 0;
    [SerializeField] float moveSpeedMultiplier = 1.5f;
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
        navAgent.speed = navAgent.speed* moveSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLookingForPlayer)
        {
            if (HideSystem.IsHidden)
            {
                OnPlayerHide();
                return;
            }
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
    void OnPlayerHide()
    {
        OnPlayerLost?.Invoke();
        isLookingForPlayer = false;
        navAgent.SetDestination(waypoints[currentIndex].transform.position);
        navAgent.speed = navAgent.speed/moveSpeedMultiplier;
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
