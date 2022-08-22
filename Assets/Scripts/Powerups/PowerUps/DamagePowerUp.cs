using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class DamagePowerUp : Powerup
{
    public DamagePowerUp powerup;
    private float boostAsPercent;
    public int boostPercent;
    private Pawn damage;
    public override void Apply(PowerupManage target)
    {
        damage = target.gameObject.GetComponent<Pawn>();
        boostAsPercent = 100 / boostPercent;
        damage.bDamage = damage.bDamage * boostAsPercent;
    }
    public override void Remove(PowerupManage target)
    {
        if (Time.time > duration)
        {
            if (isPerma == false)
            {
                damage.bDamage = damage.bDamage / boostAsPercent;
            }
        }
    }
}
