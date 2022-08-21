using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode lookLeftKey;
    public KeyCode lookRightKey;
    public KeyCode jumpKey;
    public KeyCode shootKey;
    // Start is called before the first frame update
    public override void Start()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
        base.Start();
    }
    public void OnDestroy()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                GameManager.instance.players.Remove(this);
            }
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void ProccessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.Moveforward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.Movebackward();
        }

        if (Input.GetKey(lookLeftKey))
        {
            pawn.LookLeft();
        }

        if (Input.GetKey(lookRightKey))
        {
            pawn.LookRight();
        }
        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }
}
