using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Enemy_Skeleton : Enemy
{
    public SkeletonIdleState idleState {get; private set;}
    public SkeletonMoveState moveState {get; private set;}
    public SkeletonBattleState battleState {get; private set;}
    public SkeletonAttackState attackState {get; private set;}
    public SkeletonDeadState deadState {get; private set;}
    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
        deadState = new SkeletonDeadState(this, stateMachine, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
    }
}
