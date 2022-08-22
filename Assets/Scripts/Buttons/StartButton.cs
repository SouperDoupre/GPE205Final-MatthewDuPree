using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.LoadGame();
        }
    }
}
