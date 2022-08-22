using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HealthPowerUp : Powerup
{
    public float healthToAdd;
    public override void Apply(PowerupManage target)
    {
        //Get the Health Comp from the gameObject that is being touched
        Health playerHealth = target.gameObject.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.Heal(target.GetComponent<Pawn>(), healthToAdd);
        }
    }
    public override void Remove(PowerupManage target)
    {
        //TODO : Remove health changes
    }
}
