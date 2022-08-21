using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    public float volumeDistance;
    public float noise;
    PlayerController pcon;
    // Start is called before the first frame update
    void Start()
    {
        pcon = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(pcon.moveForwardKey) || Input.GetKey(pcon.moveBackwardKey))
        {
            noise = volumeDistance;
        }
        else
        {
            noise = 0;
        }
    }
}
