using Godot;
using System;
using Com.IsartDigital.Manager;

public class Wall : Node2D
{
    private Area2D hitBox;

    public override void _Ready()
    {
        hitBox = GetNode<Area2D>(StrManager.ENTITIES_HITBOX_PATH);
        base._Ready();
    }
}
