using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    Rigidbody rb;
    private float lastTimeShot;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void Moveforward()
    {
        if(rb != null)
        {
            movement.Move(transform.forward, moveSpeed);
        }
    }
    public override void Movebackward()
    {
        if(rb != null)
        {
            movement.Move(transform.forward.normalized, -moveSpeed);
        }
    }
    public override void LookLeft()
    {
        if(rb != null)
        {
            movement.Rotate(-lookSpeed);
        }
    }
    public override void LookRight()
    {
        if(rb != null)
        {
            movement.Rotate(lookSpeed);
        }
    }
    public override void Shoot()
    {
        float secondsPerShot = 1 / fireRate;
        if(Time.time > lastTimeShot + secondsPerShot)
        {
            if(rb != null)
            {
                shooter.Shoot(bullet, bSpeed, bDamage, bLife);
            }
            lastTimeShot = Time.time;
        }
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        if(rb != null)
        {
            //Where is the target in relation to the pawn
            Vector3 vectorToTarget = targetPosition - transform.position;
            //How to look
            Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
            //Restricts the speed of hea turn
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
        }
    }
}
