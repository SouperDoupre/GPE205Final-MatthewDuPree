using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMap : MonoBehaviour
{
    public Toggle randomToggle;
    public bool isRandom;
    public Toggle motdToggle;
    public bool MOTD;

    public void RandomSeed()
    {
        if (randomToggle.isOn)
        {
            GameManager.instance.GetComponent<RoomManager>().isRandom = true;
            isRandom = true;
        }
    }
}
