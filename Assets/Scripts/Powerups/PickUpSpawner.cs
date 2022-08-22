using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject pickupPreFab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;
    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
        nextSpawnTime = Time.deltaTime + spawnDelay;

    }

    // Update is called once per frame
    void Update()
    {
        //If there isnt a pickup
        if (spawnedPickup == null)
        {
            //and if if tis time to spawn a pickup
            if (Time.time > nextSpawnTime)
            {
                //spawn it and set the next time
                spawnedPickup = Instantiate(pickupPreFab, tf.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            //Otherwise, the object still exists, postpone the spawn
            nextSpawnTime = Time.time + spawnDelay;
        }

    }
}
