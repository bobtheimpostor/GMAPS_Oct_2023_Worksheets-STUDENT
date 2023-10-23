using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new Vector3(-gravityStrength, -force, 0f);
        moveDir = new Vector3(-force, gravityStrength, 0f);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(gravityNorm,
            moveDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(angle, 0, 0));

        DebugExtension.DebugArrow(rb.position, gravityNorm, Color.red);

        DebugExtension.DebugArrow(rb.position, moveDir, Color.blue);
    }
}


