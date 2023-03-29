using Godot;
using System;
using System.Collections.Generic;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Entities
{

    public class Kiddo : Node2D
    {
        [Export] NodePath pathContainerPath;
        [Export] NodePath entityPath;

        Node2D pathContainer;
        Node2D entity;

        Vector2 velocity = new Vector2(1, 1);

        List<Node2D> pathList = new List<Node2D>();
        int index = 0;

        public override void _Ready()
        {
            entity = (Node2D)GetNode(entityPath);
            pathContainer = (Node2D)GetNode(pathContainerPath);

            foreach (Node2D item in pathContainer.GetChildren())
            {
                pathList.Add(item);
            }
        }
        public override void _PhysicsProcess(float delta)
        {
            Moving();
        }
        private void Moving()
        {
            if (entity.Position - pathList[index].Position < velocity)
            {
                GD.Print(pathList[index].Position.x);
                entity.LookAt(pathList[index].Position);
                entity.Position += velocity;
            }
            else if (index < pathList.Count -1) index += 1;
            else index = 0;
        }
    }

}