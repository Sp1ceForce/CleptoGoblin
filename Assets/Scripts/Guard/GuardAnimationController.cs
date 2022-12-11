using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAnimationController : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;

    bool isRunning = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        GetComponentInParent<GuardFOV>().OnPlayerDetected += OnPlayerDetected;
        GetComponentInParent<GuardMoving>().OnPlayerLost += OnPlayerLost;

    }

    void OnPlayerDetected(GameObject player)
    {
        isRunning = true;
        animator.SetBool("isRunning", isRunning);
    }
    void OnPlayerLost()
    {
        isRunning = false;
        animator.SetBool("isRunning", isRunning);
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", !agent.isStopped);
    }
}
