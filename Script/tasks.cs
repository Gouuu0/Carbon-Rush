using Godot;
using System;

public class tasks : Node2D
{
    [Export] PackedScene Particle2DScene;
    Particles2D elParticulo;

    bool isActive = true;

    public override void _Ready()
    {
        elParticulo = Particle2DScene.Instance<Particles2D>();
        AddChild(elParticulo);
        elParticulo.OneShot = true;
    }

    public override void _Process(float delta)
    {
        if (isActive)
        {
            if (Player.pos.DistanceTo(GlobalPosition) < 100) isActive = false;
            elParticulo.Emitting = true;
            carbonbar.carbonLevel += .0025f;
        }
    }
}
