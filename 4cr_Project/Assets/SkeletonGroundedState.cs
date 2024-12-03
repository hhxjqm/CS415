using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SkeletonGroundedState : EnemyState
{
    protected Enemy_Skeleton enemy;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName, enemy)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("SEEEEEE");
        if(enemy.IsPlayerDetected()) {
            Debug.Log("OOOOKKKKK");
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
