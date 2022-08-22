using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManage : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> powerupRemoveQueue;
    // Start is called before the first frame update
    void Start()
    {
        powerupRemoveQueue = new List<Powerup>();
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }
    public void Add(Powerup powerupToAdd)
    {
        powerupToAdd.Apply(this);
        powerups.Add(powerupToAdd);
    }
    public void Remove(Powerup powerupToRemove)
    {
        powerupToRemove.Remove(this);
        powerupRemoveQueue.Add(powerupToRemove);
    }
    public void DecrementPowerupTimers()
    {
        foreach(Powerup powerup in powerups)
        {
            powerup.duration -= Time.deltaTime;
            if(powerup.duration <= 0)
            {
                Remove(powerup);
            }
        }
    }
    private void ApplyPowerupRemoveQueue()
    {
        foreach(Powerup powerup in powerupRemoveQueue)
        {
            powerups.Remove(powerup);
        }
        powerupRemoveQueue.Clear();
    }
    private void LateUpdate()
    {
        ApplyPowerupRemoveQueue();
    }
}
