using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    //where to shoot from
    public Transform firePoint;

    public abstract void Shoot(GameObject bullet, float bSpeed, float bDamage, float bLife);
}
