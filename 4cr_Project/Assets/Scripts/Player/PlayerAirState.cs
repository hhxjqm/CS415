using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        
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

        if (player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }
        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * .8f * xInput, rb.linearVelocity.y);
        if (player.IsGroundDetected())
        {
            // player.SetVelocity(player.moveSpeed * .8f * xInput, rb.linearVelocity.y);
            stateMachine.ChangeState(player.idleState);
        }
    }
}
