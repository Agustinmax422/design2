using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{
    public float speed = 30f;
    private new Rigidbody rigidbody;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    private Vector2 velocity;
    private Vector2 frameVelocity;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _look();
    }
  
    private void _Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = transform.forward * ver + transform.right * hor;

            rigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
    }
    private void _look()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        transform.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
}

