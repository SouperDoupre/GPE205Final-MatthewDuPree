using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode lookLeftKey;
    public KeyCode lookRightKey;
    public KeyCode jumpKey;
    public KeyCode shootKey;
    public float score;
    public Text scoreDis;
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
        if(scoreDis != null)
        {
            scoreDis.text = "Score: " + score;
        }
        if(pawn == null)
        {
            GameManager.instance.ChangeState(GameManager.GameStates.GameOverScreen);
        }
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
    public void AddScore(float amount)
    {
        score = score + amount;
    }
}
