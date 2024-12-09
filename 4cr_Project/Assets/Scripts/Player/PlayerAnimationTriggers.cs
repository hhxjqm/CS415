using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackChcekRadius);
         foreach(var hit in colliders)
         {
            if(hit.GetComponent<Enemy>() != null) 
            {
                EnemyStats _target = hit.GetComponent<EnemyStats>();
                player.stats.DoDamage(_target);

                // hit.GetComponent<Enemy>().Damage();
                // hit.GetComponent<CharacterStats>().TakeDamage(player.stats.damage.GetValue());
            }
         }
    
    
    }
}
