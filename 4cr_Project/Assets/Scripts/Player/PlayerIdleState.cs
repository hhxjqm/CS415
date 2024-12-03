using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroXVelocity();
        Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0 && !player.isBusy)
        {
            if (!player.IsWallDetected() || (player.IsWallDetected() && (player.facingDir < 0 && xInput > 0) || (player.facingDir > 0 && xInput < 0)))
            {
                stateMachine.ChangeState(player.moveState);
            } else {
                return;
            }
        }
    }
}
