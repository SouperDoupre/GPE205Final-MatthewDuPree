using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOfTheDay : MonoBehaviour
{
    public Toggle motdToggle;
    public bool MOTD;
    public Toggle randomToggle;
    public bool isRandom;

    public void MOTDSeed()
    {
        if (motdToggle.isOn)
        {
            GameManager.instance.GetComponent<RoomManager>().MapOfTheDay = true;
            MOTD = true;
        }
    }
}
