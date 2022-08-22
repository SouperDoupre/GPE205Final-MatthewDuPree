using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIExploder : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void MakeDescisions()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if(IsDisLessThan(target, 5))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Chase:
                DoChaseState();
                break;
        }
    }
}
