using Godot;
using System;
using Com.IsartDigital.Manager;
//Author : Merfoud Kélyan

namespace Com.IsartDigital.Entities
{

    public class RandomObject : Area2D
    {
        protected bool isConnect = false;
        protected bool isActivated = true;

        protected AnimatedSprite sprite;
        public override void _Ready()
        {
            Connect(StrManager.AREA_ENTERED, this, nameof(OnAreaEntered));
            Connect(StrManager.AREA_EXITED, this, nameof(OnAreaExited));
            sprite = GetChild(0) as AnimatedSprite;
        }
        public override void _PhysicsProcess(float delta)
        {
            if (Input.IsActionJustPressed(StrManager.CLICK) && isConnect) OnClick();
        }
        protected void OnAreaEntered(Area2D pArea)
        {
            if (pArea.Name.Contains((StrManager.ENTITIES_HITBOX_PATH))) { isConnect = true; Scale = new Vector2(1.2f, 1.2f); }
            
        }
        protected void OnAreaExited()
        {
            isConnect = false; Scale = new Vector2(1f, 1f);
        }
        protected virtual void OnClick()
        {
            sprite.Animation = StrManager.ANIM_TURN_OFF;
            isActivated = false;
        }
    }

}