using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = .4f;
        player.SetVelocity(10 * -player.facingDir, player.jumpForce);
    }   

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0)
            stateMachine.ChangeState(player.airState);
        if (xInput != 0 && rb.linearVelocity.y < 0)
            player.SetVelocity(player.moveSpeed * .8f * xInput, rb.linearVelocity.y);
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}


