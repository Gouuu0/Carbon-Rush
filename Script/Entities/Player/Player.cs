using Godot;
using System;
using Com.IsartDigital.Manager;

public class Player : Entities
{
    [Export] NodePath DashTimerPath;
    Timer DashTimer;

    [Export] NodePath DashTimerPath2;
    Timer DashTimer2;

    [Export] float SLIP_FORCE = 1.2f;
    private bool onGround = false;
    
    private bool dashReady = true;

    AnimatedSprite player;

    public override void _Ready()
    {
        DashTimer = GetNode<Timer>(DashTimerPath);
        DashTimer2 = GetNode<Timer>(DashTimerPath2);
        DashTimer.Connect("timeout", this, nameof(TimerGaming));
        DashTimer2.Connect("timeout", this, nameof(TimerGaming2));
        base._Ready();
        Act = InputMovements;
    }
    public override void _Process(float delta)
    {
        PositionChange();

        if (Input.IsActionJustPressed("LeftClick") && dashReady)
        {
            LookAt(GetGlobalMousePosition());
            Act = Dash;
            dashReady = false;
            DashTimer.Start();
            DashTimer2.Start();
            CollisionMask += 2;
            CollisionMask -= 1;
        }
        base._Process(delta);
        player = GetChild(0) as AnimatedSprite;
    }

    void Dash()
    {
        MoveAndSlide(new Vector2(1000,0).Rotated(Rotation));
    }

    private void InputMovements()
    {
        float lSpeedToGive = speed;

        if (Input.IsActionPressed(StrManager.UP) && onGround)
        {
            velocity.y = -30;
            onGround = false;
        }
        if (Input.IsActionPressed(StrManager.DOWN))
        {
            velocity.y += lSpeedToGive;
        }
        if (Input.IsActionPressed(StrManager.RIGHT))
        {
            velocity.x += lSpeedToGive;
        }
        if (Input.IsActionPressed(StrManager.LEFT))
        {
            velocity.x -= lSpeedToGive;
        }

        MoveAndSlide(new Vector2(0, 300));
    }

    private void PositionChange()
    {
        MoveAndSlide(velocity*100);

        velocity /= SLIP_FORCE;
    }

    protected override void AreaEntered(Area2D pArea)
    {
        if(pArea.Name.StartsWith("Bobby"))
            onGround = true;

    }

    void TimerGaming()
    {
        CollisionMask += 1;
        CollisionMask -= 2;
        Act = InputMovements;
        RotationDegrees = 0;
    }
    void TimerGaming2()
    {
        dashReady = true;
    }
}