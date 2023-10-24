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
        gravityDir = planet.transform.position - transform.position;
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(moveDir,
            transform.position, Vector3.forward);

        Debug.Log(angle);

        rb.MoveRotation(Quaternion.Euler(0, 0, -angle));

        DebugExtension.DebugArrow(rb.position, gravityNorm, Color.red);

        DebugExtension.DebugArrow(rb.position, moveDir, Color.blue);
    }
}


