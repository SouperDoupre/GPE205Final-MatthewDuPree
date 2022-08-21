using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(Pawn source, float damage)
    {
        currentHealth = currentHealth - damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(source != null)
        {
            Debug.Log(source.name + " did " + damage + " damage to " + gameObject.name);
        }
        if(currentHealth <= 0)
        {
            Die(source);
        }
    }
    public void Die(Pawn pawn)
    {
        Destroy(gameObject);
    }
    public void Heal(Pawn pawn, float healing)
    {
        currentHealth = currentHealth + healing;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
