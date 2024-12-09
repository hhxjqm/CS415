using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : Entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;

    public bool isBusy {get; private set;}
    [Header("Move indo")] 
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir {get; private set;}

    public PlayerStateMachine stateMachine {get; private set;}

    public PlayerIdleState idleState {get; private set;}

    public PlayerMoveState moveState {get; private set;}
    public PlayerJumpState jumpState {get; private set;}
    public PlayerAirState airState {get; private set;}
    public PlayerWallSlideState wallSlide {get; private set;}
    public PlayerWallJumpState wallJump {get; private set;}
    public PlayerPrimaryAttack primaryAttack {get; private set;}
    public PlayerDashState dashState {get; private set;}    
    public PlayerDeadState deadState {get; private set;}

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this,stateMachine,"Idle");
        moveState = new PlayerMoveState(this,stateMachine,"Move");
        jumpState = new PlayerJumpState(this,stateMachine,"Jump");
        airState = new PlayerAirState(this,stateMachine,"Jump");
        dashState = new PlayerDashState(this,stateMachine,"Dash");
        wallSlide = new PlayerWallSlideState(this,stateMachine,"WallSlide");
        wallJump = new PlayerWallJumpState(this,stateMachine,"WallJump");
        primaryAttack = new PlayerPrimaryAttack(this,stateMachine,"Attack");

        
        deadState = new PlayerDeadState(this,stateMachine,"Die");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        dashUsageTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (IsWallDetected())
                dashDir = -facingDir;
            else if (dashDir == 0)
                dashDir = facingDir;
            stateMachine.ChangeState(dashState);
        }
    }

    public virtual bool IsDashDectected()
    {
        if (stateMachine.currentState == dashState)
            return true;
        else
            return false;
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
    }
}
