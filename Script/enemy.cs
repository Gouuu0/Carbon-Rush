using Godot;
using System;

public class enemy : RayCast2D
{
    [Export] NodePath rayycastPath;
    RayCast2D raycast;

    [Export] NodePath collisionPath;
    Area2D collision;

    public override void _Ready()
    {
        raycast = GetNode<RayCast2D>(rayycastPath);
        collision = GetNode<Area2D>(collisionPath);
        collision.Connect("area_entered", this, nameof(OnCollision));
    }

    public override void _Process(float delta)
    {
        raycast.CastTo = Player.pos - GlobalPosition;
        GD.Print(raycast.GetCollider());
    }

    void OnCollision(Area2D pColliding)
    {
    }
}
