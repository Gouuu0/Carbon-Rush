using Godot;
using System;
using Com.IsartDigital.Manager;

namespace Com.IsartDigital.Entities
{
    public class Entities : KinematicBody2D
    {
        [Export] public int TEAM = 0;
        [Export] protected float BASE_SPEED = 2.5f;

        protected Vector2 velocity;
        protected Area2D hitBox;
        protected float speed;

        public Action Act;

        public override void _Ready()
        {
            speed = BASE_SPEED;
            hitBox = GetNode<Area2D>(StrManager.ENTITIES_HITBOX_PATH);
            hitBox.Connect(StrManager.AREA_ENTERED, this, nameof(AreaEntered));

            Act = DoIdle;
        }

        public override void _Process(float delta)
        {
            Act();
        }

        protected virtual void DoIdle()
        {

        }

        protected virtual void DoBasePatern()
        {

        }

        protected virtual void AreaEntered(Area2D pArea)
        {

        }
    }
}