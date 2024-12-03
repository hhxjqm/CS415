using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }
        // if(Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     stateMachine.ChangeState(player.dashState);
        //     return;
        // }
        if(xInput != 0 && player.facingDir != xInput)
            stateMachine.ChangeState(player.idleState);

        if (yInput < 0)
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        else 
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y * .7f);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
