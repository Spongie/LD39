using System;
using UnityEngine;

public class Health : MonoBehaviour 
{
    public float MaxHealth = 100f;
    public float CurrentHealth;
    
	void Start () 
	{
        SetHealth(MaxHealth);
	}

    public void DealDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float CurrentHealthLevel { get { return CurrentHealth / MaxHealth; } }

    internal void SetHealth(float health)
    {
        MaxHealth = health;
        CurrentHealth = MaxHealth;
    }
}