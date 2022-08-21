using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeShoot : Shooter
{
    public override void Shoot(GameObject bullet, float bSpeed, float bDamage, float bLife)
    {
        //Create the hurt ball
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        //Get the damage
        BulletDamage bulDam = newBullet.GetComponent<BulletDamage>();
        //If it can do damage
        if(bulDam != null)
        {
            bulDam.damage = bDamage;

            bulDam.owner = GetComponent<Pawn>();
        }

        Rigidbody body = newBullet.GetComponent<Rigidbody>();

        if(body != null)
        {
            body.AddForce(firePoint.forward * bSpeed);
        }
        Destroy(newBullet, bLife);
    }
}
