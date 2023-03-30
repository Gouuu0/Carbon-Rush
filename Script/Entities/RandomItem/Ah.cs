using Godot;
using System;
using Com.IsartDigital.Manager;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Entities.RandomItem
{

    public class Ah : RandomObject
    {
        protected override void OnClick()
        {
            sprite.Animation = StrManager.ANIM_TURN_OFF;
            isActivated = false;
        }
    }

}