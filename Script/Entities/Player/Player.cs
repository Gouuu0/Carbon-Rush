using Godot;
using System;
using Com.IsartDigital.Manager;

public class Player : Entities
{
    [Export] float SLIP_FORCE = 1.2f;
    private bool onGround = false;

    public override void _Process(float delta)
    {
        InputMovements();
        PositionChange();
        base._Process(delta);
    }

    private void InputMovements()
    {
        float lSpeedToGive = speed;

        if (Input.IsActionPressed(StrManager.UP))
        {
            velocity.y -= lSpeedToGive;
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
    }

    private void PositionChange()
    { 
        if (onGround && velocity.y > 0) velocity = new Vector2(velocity.x, 0);

        Position += velocity;

        velocity /= SLIP_FORCE;
    }

    protected override void AreaEntered(Area2D pArea)
    {
        Node2D lNode = (Node2D)pArea.GetParent();

        if (lNode is Wall)
        {
            onGround = true;
        }
    }
}