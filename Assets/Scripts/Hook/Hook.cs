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
    [SerializeField] private AudioSource HookThrow;
    private int layerMask;
    private SpringJoint hookJoint;
    private bool stagePrepare = false;
    private bool stageHook = false;
    private int i = 1;
    private PlayerController pl;
    private void Start()
    {
        int wallIndexLayer = LayerMask.NameToLayer("Wall");
        int itemIndexLayer = LayerMask.NameToLayer("item");
        mainCam = Camera.main;
        layerMask = (1 << wallIndexLayer);
        // layerMask = ~layerMask;

        pl = GetComponent<PlayerController>();
    }
    void Update()
    {
        HookLogic();
    }

    private void HookLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HookThrow.Play();
            gameObject.SendMessage("Freze", true);

            pl.isAiming = false;

            pl.isThrow = true;
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
            gameObject.SendMessage("Freze", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReturnHook();
            gameObject.SendMessage("Freze", false);

        }


    }
    public void ReturnHook()
    {
        pl.isThrow = false;

        Destroy(hookJoint);
        hookRender.ReturnRope();
    }

    // ?????????????? ???????????? ?? ?????????? ??????????????????. ???????????? ?????????? ?????????? ???? ???????????????? ?????????? ?????????????????? :3 . ???????????????? ?? ???????????????? ?????????????????????? ??????????
    // private void HookLogic()
    // {
    //     // if (i == 1) pl.isThrow = false;  
    //     if (Input.GetMouseButtonDown(0) && i == 1)
    //     {
    //         pl.isAiming = true;
    //         i++;
    //         gameObject.SendMessage("Freze", true);
    //         //???????????????? ????????????????
    //     }
    //     else if (Input.GetMouseButtonDown(0) && i == 2)
    //     {
    //         pl.isAiming = false;

    //         pl.isThrow = true;
    //         i = 1;
    //         RaycastHit hit;
    //         Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             RaycastHit hitNotWall;

    //             var heading = hit.point - transform.position;
    //             var distance = heading.magnitude;
    //             var direction = heading / distance;
    //             if (Physics.Raycast(transform.position, direction, out hitNotWall, 200, layerMask)) return;


    //             var tmpVector = hit.point;
    //             // if (hit.distance > hookDistance)
    //             // {
    //             //     tmpVector = Vector3.forward * hookDistance;
    //             // }
    //             transform.TransformDirection(tmpVector);

    //             if (hit.point != null)
    //             {
    //                 Vector3 grabPoint = tmpVector;
    //                 hookRender.DrawRope(grabPoint);

    //                 hookJoint = this.gameObject.AddComponent<SpringJoint>();
    //                 hookJoint.autoConfigureConnectedAnchor = false;
    //                 hookJoint.connectedAnchor = grabPoint;

    //                 float grapDistance = Vector3.Distance(transform.position, grabPoint);
    //                 hookJoint.maxDistance = grapDistance;
    //                 hookJoint.minDistance = grapDistance;
    //                 hookJoint.damper = hookJointDamper;
    //                 hookJoint.spring = hookJointSpring;
    //             }
    //         }
    //         gameObject.SendMessage("Freze", false);
    //     }
    //     else if (Input.GetMouseButtonDown(1) && i == 2)
    //     {
    //         i = 1;
    //         gameObject.SendMessage("Freze", false);
    //         pl.isThrow = false;

    //     }
    // }
}
