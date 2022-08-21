using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    public Movement movement;
    public Shooter shooter;
    public float moveSpeed;
    public float lookSpeed;
    //Hurt ball
    public GameObject bullet;
    //bullet speed
    public float bSpeed;
    //bullet lifespan
    public float bLife;
    //bullet fire rate
    public float fireRate;
    //bullet damage
    public float bDamage;
    //Enemy hearing
    public float hearingDistance;
    //Enemy patrol looping?
    public bool isLooping;

    // Start is called before the first frame update
    public virtual void Start()
    {
        shooter = GetComponent<Shooter>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public abstract void Moveforward();
    public abstract void Movebackward();
    public abstract void LookLeft();
    public abstract void LookRight();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);
}
