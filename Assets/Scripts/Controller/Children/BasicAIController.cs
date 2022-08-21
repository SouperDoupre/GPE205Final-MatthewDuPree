using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIController : AIController
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
        if(pawn != null)
        {
            TargetPlayer();
            if(target != null)
            {
                switch (currentState)
                {
                    case AIStates.Idle:
                        DoIdleState();
                        if (CanHear())
                        {
                            ChangeState(AIStates.Alert);
                        }
                        if (CanSee(target))
                        {
                            ChangeState(AIStates.Chase);
                        }
                        if(IsDisLessThan(target, 5))
                        {
                            ChangeState(AIStates.Chase);
                        }
                        break;
                    case AIStates.Chase:
                        DoChaseState();
                        if(IsDisLessThan(target, 5))
                        {
                            ChangeState(AIStates.Attack);
                            pawn.moveSpeed = pawn.moveSpeed / 2;
                        }
                        if(IsDisGreaterThan(target, 10))
                        {
                            ChangeState(AIStates.RTB);
                        }
                        break;
                    case AIStates.Attack:
                        DoAttackState();
                        if(IsDisGreaterThan(target, 6))
                        {
                            ChangeState(AIStates.Chase);
                            pawn.moveSpeed = pawn.moveSpeed * 2;
                        }
                        break;
                    case AIStates.RTB:
                        DoRTB();
                        if(AmIAtBase(post, .5f))
                        {
                            ChangeState(AIStates.Idle);
                        }
                        break;
                }
            }
        }
    }
}
