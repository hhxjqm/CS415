using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    protected override void Start()
    {
        base.Start();    
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
        enemy.Damage();
    }

    public override void Die()
    {
        base.Die();
        enemy.Die();

        Destroy(gameObject, 3f);
    }
}
