using System.Collections;
using UnityEngine;

public class GuardFOV : MonoBehaviour
{
    public System.Action<GameObject> OnPlayerDetected;
    
    
    [SerializeField] float detectionRadius;
    [Range(0,360)]
    [SerializeField] float visionAngle;

    //Masks for player and obstacles
    public LayerMask TargetMask;
    public LayerMask ObstacleMask;

    //Delay between vision checks
    float delay = 0.2f;

    //Player object reference 
    GameObject playerRef;

    bool seenPlayer;
    void Start()
    {
        StartCoroutine(VisionRoutine());
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }


    void VisionCheck()
    {        
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, TargetMask);
        if (colliders.Length != 0)
        {
            Transform target = colliders[0].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward,dirToTarget) < visionAngle / 2)
            {
                float distance = Vector3.Distance(transform.position,target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distance, ObstacleMask))
                {
                    OnPlayerDetected?.Invoke(target.gameObject);
                    StopCoroutine(VisionRoutine());
                }
            }
        }
    }
    IEnumerator VisionRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            VisionCheck();
        }
    }
}
