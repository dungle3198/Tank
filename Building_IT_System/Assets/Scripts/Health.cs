using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float currentHealth;
    [SerializeField]
    float maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void applyDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public float getCurrentHealth()
    {
        return this.currentHealth;
    }
    public float setMaxHealth(float amount)
    {
        maxHealth = amount;
        GainFullHealth();
        return maxHealth;

    }
    public float getMaxHealth()
    {
        return maxHealth;
    }
    public float getHealthPercentage()
    {
        return (currentHealth / maxHealth);
    }
    public float GainFullHealth()
    {
        currentHealth = maxHealth;
        return currentHealth;
    }
}
