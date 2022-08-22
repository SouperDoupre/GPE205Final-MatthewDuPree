using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public void Credits()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateCreditsScreen();
        }
    }
}
