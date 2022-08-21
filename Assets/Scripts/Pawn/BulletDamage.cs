using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public Pawn owner;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //Get the health component off the target
        Health eHealth = other.gameObject.GetComponent<Health>();

        if(eHealth != null)
        {
            eHealth.TakeDamage(owner, damage);
        }
        Destroy(gameObject);
    }
}
