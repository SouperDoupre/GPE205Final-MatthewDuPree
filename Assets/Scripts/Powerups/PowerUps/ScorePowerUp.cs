using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ScorePowerUp : Powerup
{
    public ScorePowerUp powerup;
    public float scoreIncrease;
    Pawn pawn;

    public override void Apply(PowerupManage target)
    {
        pawn = target.GetComponent<Pawn>();
        GameManager.FindObjectOfType<PlayerController>().AddScore(scoreIncrease);
    }

    public override void Remove(PowerupManage target)
    {
        //this is permanent
    }
}
