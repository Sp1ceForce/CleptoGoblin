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
    private int layerMask;
    private SpringJoint hookJoint;
    private bool stagePrepare = false;
    private bool stageHook = false;
    private int i = 1;
    private void Start()
    {
        int wallIndexLayer = LayerMask.NameToLayer("Wall");
        int itemIndexLayer = LayerMask.NameToLayer("item");

        layerMask = (1 << wallIndexLayer);
        // layerMask = ~layerMask;
    }
    void Update()
    {
        HookLogic();
    }

    private void HookLogic()
    {
        if (Input.GetMouseButtonDown(0) && i == 1)
        {
            i++;
            gameObject.SendMessage("Freze", true);
            //включить анимацию
        }
        else if (Input.GetMouseButtonDown(0) && i == 2)
        {
            i = 1;
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                RaycastHit hitNotWall;

                var heading = hit.point - transform.position;
                var distance = heading.magnitude;
                var direction = heading / distance;
                if (Physics.Raycast(transform.position, direction, out hitNotWall, 200, layerMask)) return;


                var tmpVector = hit.point;
                // if (hit.distance > hookDistance)
                // {
                //     tmpVector = Vector3.forward * hookDistance;
                // }
                transform.TransformDirection(tmpVector);

                if (hit.point != null)
                {
                    Vector3 grabPoint = tmpVector;
                    hookRender.DrawRope(grabPoint);

                    hookJoint = this.gameObject.AddComponent<SpringJoint>();
                    hookJoint.autoConfigureConnectedAnchor = false;
                    hookJoint.connectedAnchor = grabPoint;

                    float grapDistance = Vector3.Distance(transform.position, grabPoint);
                    hookJoint.maxDistance = grapDistance;
                    hookJoint.minDistance = grapDistance;
                    hookJoint.damper = hookJointDamper;
                    hookJoint.spring = hookJointSpring;
                }
            }
            gameObject.SendMessage("Freze", false);

        }
        else if (Input.GetMouseButtonDown(1) && i == 2)
        {
            i = 1;
            gameObject.SendMessage("Freze", false);

        }
    }
    public void ReturnHook()
    {
        Destroy(hookJoint);
        hookRender.ReturnRope();
    }
}
