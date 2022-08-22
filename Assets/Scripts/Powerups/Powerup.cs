using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup
{
    public float duration;
    public bool isPerma;
    public abstract void Apply(PowerupManage target);
    public abstract void Remove(PowerupManage target);

}
