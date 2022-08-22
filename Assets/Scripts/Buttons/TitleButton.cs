using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateTitleScreen();
        }
    }
}
