using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public Vector2 boundsMin = new Vector2(-10f, -10f);
    public Vector2 boundsMax = new Vector2(10f, 10f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * moveSpeed;
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, boundsMin.x, boundsMax.x);
        float clampedZ = Mathf.Clamp(transform.position.z, boundsMin.y, boundsMax.y);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
