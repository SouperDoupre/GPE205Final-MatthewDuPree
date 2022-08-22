using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void Resume()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ResumeGame();
        }
    }
}
