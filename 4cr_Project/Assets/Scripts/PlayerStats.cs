using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerStats : CharacterStats
{
    private Player player;
    private GameManager gameManager;
    protected override void Start()
    {
        base.Start();   
        gameManager = GameManager.instance;
        player = GetComponent<Player>(); 
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
        player.Damage();
        ChangeHealth();
    }

    public override void Die()
    {
        base.Die();
        player.Die();
        Destroy(gameObject, 3f);
        // Invoke("GameOver", 3f);
        gameManager.GameOver();

        // gameManager.RestartScene();
        // restartButton.SetActive(true);
    }

    public void ChangeHealth()
    {
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth.GetValue());
    }
}
