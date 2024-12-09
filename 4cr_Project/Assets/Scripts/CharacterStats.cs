using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
    public Stat strength;
    public Stat damage;
    public Stat maxHealth;
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();

        damage.AddModifier(4);
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue() + strength.GetValue();
        _targetStats.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die()
    {
        // throw new NotImplementedException("Die method not implemented");
        // Destroy(gameObject);
    }

    public void KillEntity() => Die();
}
