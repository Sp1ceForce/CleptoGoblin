using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float hookDistance;
    [SerializeField] private float hookJointDamper = 10;
    [SerializeField] private float hookJointSpring = 5;
    [SerializeField] private Camera mainCam;
    [SerializeField] private HookRender hookRender;


    private SpringJoint hookJoint;

    void Update()
    {
        HookLogic();
    }

    private void HookLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log(objectHit.position);
                if (hit.collider != null)
                {
                    Vector3 grabPoint = objectHit.position;
                    hookRender.DrawRope(grabPoint);
                    hookJoint = this.gameObject.AddComponent<SpringJoint>();
                    hookJoint.autoConfigureConnectedAnchor = false;
                    hookJoint.connectedAnchor = grabPoint;

                    float grapDistance = Vector3.Distance(transform.position, grabPoint);
                    hookJoint.maxDistance = grapDistance;
                    hookJoint.minDistance = grapDistance;
                    hookJoint.damper = 10;
                    hookJoint.spring = 5;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(hookJoint);
            hookRender.ReturnRope();
        }
    }
}
