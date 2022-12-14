using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody rbModel;
    private Vector2 moveXZ;
    [SerializeField] private float speed = 1;
    [SerializeField] private float speedRotate = 1;

    private Camera mainCam;
    public bool isAiming;
    public bool isCrouched;
    public bool isRuning;
    public bool isThrow;
    public bool isIdle;


    void Start()
    {
        isAiming = false;
        rb = GetComponent<Rigidbody>();
        rbModel = transform.GetChild(0).GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }
    void FixedUpdate()
    {
        MovementLogic();
        AnimatLogic();
    }

    private void MovementLogic()
    {
        float deltaX = Input.GetAxisRaw("Horizontal");
        float deltaZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(deltaX, 0, deltaZ).normalized * speed;
        //move = transform.TransformDirection(move);
        rb.AddForce(move, ForceMode.Impulse);

        moveXZ.x = rb.velocity.x;
        moveXZ.y = rb.velocity.z;
        moveXZ = Vector2.ClampMagnitude(moveXZ, speed);
        rb.velocity = new Vector3(moveXZ.x, rb.velocity.y, moveXZ.y);
        // rb.velocity = move;
        if (!(isAiming || (deltaX == 0 && deltaZ == 0)))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z)), 0.1f);
        }

        if (isAiming)
        {
            isRuning = false;

            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            var heading = hit.point - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), 0.1f);
        }
    }

    public void Freze(bool value)
    {
        if (value)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | ~RigidbodyConstraints.FreezeRotationY; ;
            isAiming = true;
        }
        else
        {
            rb.constraints = ~RigidbodyConstraints.FreezePosition;
            isAiming = false;
        }
    }

    public void AnimatLogic()
    {
        if (Mathf.Abs(rb.velocity.x) >= 0.03 || Mathf.Abs(rb.velocity.z) >= 0.03)
        {
            isRuning = true;
        }
        else if (!isAiming)
        {
            isIdle = true;
            isRuning = false;
        }

    }
}
