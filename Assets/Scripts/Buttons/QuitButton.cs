using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.QuitGame();
        }
    }
}
