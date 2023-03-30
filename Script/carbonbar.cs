using Godot;
using System;

public class carbonbar : TextureProgress
{
    public static float carbonLevel = 0;



    public override void _Process(float delta)
    {
        Value = carbonLevel;
        if (carbonLevel >= 100)
        {
            carbonLevel = 0;
            GetTree().ChangeScene("res://Scenes/TitleCard.tscn");
        }
    }
}
