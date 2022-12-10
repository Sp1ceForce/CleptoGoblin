using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody rbModel;
    private Vector2 moveXZ;
    [SerializeField] private float speed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbModel = transform.GetChild(0).GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 move = new Vector3(deltaX, 0, deltaZ);
        move = transform.TransformDirection(move);
        rb.AddForce(move, ForceMode.Impulse);

        moveXZ.x = rb.velocity.x;
        moveXZ.y = rb.velocity.z;
        moveXZ = Vector2.ClampMagnitude(moveXZ, speed);
        rb.velocity = new Vector3(moveXZ.x, rb.velocity.y, moveXZ.y);

        if (rb.velocity != Vector3.zero)
            rbModel.MoveRotation(Quaternion.LookRotation(rb.velocity));
    }
}
