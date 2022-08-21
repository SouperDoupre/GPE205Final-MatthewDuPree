using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMove : Movement
{
    private Rigidbody body;
    // Start is called before the first frame update
    public override void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        body.MovePosition(body.position + moveVector);
    }
    public override void Rotate(float lookSpeed)
    {
        transform.Rotate(0, lookSpeed * Time.deltaTime, 0);
    }
}
