using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates { Idle, Alert, Chase, Attack, RTB }
    public AIStates currentState;
    public GameObject target;
    public GameObject post;
    public Transform health;
    public Transform[] waypoints;
    public float waypointStopDistance;
    public float FOV;
    public float maxViewDistance;
    private int currentWaypoint = 0;
    protected float lastStateChangeTime;
    public float killPoint;
    private bool isDead;
    public bool isLooping;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        isDead = false;
        TargetPlayer();
        if (GameManager.instance != null)
        {
            if (GameManager.instance.enemies != null)
            {
                GameManager.instance.enemies.Add(this);
            }
        }
    }
    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.enemies != null)
            {
                GameManager.instance.enemies.Remove(this);
            }
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Dead();
        MakeDescisions();
    }
    public virtual void ChangeState(AIStates newState)
    {
        currentState = newState;
        lastStateChangeTime = Time.time;
    }
    public virtual void MakeDescisions()
    {

    }
    //STATES
    protected virtual void DoAquireTarget()
    {
        if(target != null)
        {
            TargetPlayer();
        }
    }
    protected virtual void DoIdleState()
    {
        Patrol();
    }
    protected virtual void DoChaseState()
    {
        if(target != null)
        {
            Chase(target);
        }
    }
    protected virtual void DoAttackState()
    {
        if(target != null)
        {
            Chase(target);
            if (CanSee(target))
            {
                if(pawn.shooter != null)
                {
                    pawn.Shoot();
                }
            }
        }
    }
    protected virtual void DoRTB()
    {
        RTB(post);
    }
    protected virtual void DoAlertState()
    {
        //Not sure what to do yet
    }
    //Behaviors
    public void RTB(GameObject postPosit)
    {
        if(postPosit != null)
        {
            pawn.RotateTowards(post.transform.position);
            pawn.Moveforward();
        }
    }
    public void Chase(Vector3 targetPosit)
    {
        if(targetPosit != null)
        {
            pawn.RotateTowards(targetPosit);
            pawn.Moveforward();
        }
    }
    public void Chase(Transform targetTrans)
    {
        if(targetTrans != null)
        {
            Chase(targetTrans.position);
        }
    }
    public void Chase(GameObject objectPosit)
    {
        if(objectPosit != null)
        {
            pawn.RotateTowards(target.transform.position);
            pawn.Moveforward();
        }
    }
    public void TargetPlayer()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                if(GameManager.instance.players.Count > 0)
                {
                    if (GameManager.instance.players[0].pawn.gameObject != null)
                    {
                        target = GameManager.instance.players[0].pawn.gameObject;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
    public void Patrol()
    {
        if(waypoints != null)
        {
            if (waypoints.Length > currentWaypoint)
            {
                Chase(waypoints[currentWaypoint]);
                if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
                {
                    currentWaypoint++;
                }
            }
            else
            {
                RestartPatrol();
            }
        }
    }
    public void RestartPatrol()
    {
        if (isLooping)
        {
            currentWaypoint = 0;
        }
        else
        {
            return;
        }
    }
    //Transitions
    protected bool IsDisLessThan(GameObject target, float distance)
    {
        if(target != null)
        {
            if(Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected bool IsDisGreaterThan(GameObject thing, float distance)
    {
        if(thing != null)
        {
            if (Vector3.Distance(pawn.transform.position, thing.transform.position) > distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected bool AmIAtBase(GameObject post, float distance)
    {
        if(post != null)
        {
            if(Vector3.Distance(pawn.transform.position, post.transform.position) <= waypointStopDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Senses
    public bool CanHear()
    {
        NoiseMaker nMaker = target.GetComponent<NoiseMaker>();
        if(nMaker == null)
        {
            if(nMaker.noise <= 0)
            {
                return false;
            }
        }
        if(nMaker.noise >= 1)
        {
            float totalDistance = nMaker.noise + pawn.hearingDistance;
            if(Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
            {
                Debug.Log("can hear");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool CanSee(GameObject target)
    {
        Vector3 enemyToTarget = target.transform.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(enemyToTarget, pawn.transform.forward);
        if(target != null)
        {
            if(angleToTarget < FOV && enemyToTarget.magnitude <= maxViewDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool HasLineOfSight()
    {
        RaycastHit hit;
        Vector3 eyes = pawn.shooter.firePoint.transform.position + new Vector3(.5f, 0);
        Vector3 agentToTargetVector = target.transform.position - eyes;
        if(Physics.Raycast(eyes, agentToTargetVector, out hit, maxViewDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawLine(eyes, target.transform.position, Color.white);
                Debug.Log("Can See");
                pawn.RotateTowards(target.transform.position);
            }
        }
        return false;
    }
    public void Dead()
    {
        if (pawn == null && !isDead)
        {
            GameManager.FindObjectOfType<PlayerController>().AddScore(killPoint);
            isDead = true;
        }
    }
}
