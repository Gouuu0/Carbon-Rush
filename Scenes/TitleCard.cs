using Godot;
using System;
using System.Collections.Generic;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Manager {

	public class TitleCard : Node2D
	{
        static private TitleCard instance;
        [Export] private NodePath buttonContainerPath;
        Node2D buttonContainer;

        public override void _Ready()
        {
            buttonContainer = (Node2D)GetNode(buttonContainerPath);

            instance = null;
            if (instance != null)
            {
                QueueFree();
            }
            instance = this;

            foreach (Button item in buttonContainer.GetChildren())
            {
                item.Connect(StrManager.PRESSED, this, nameof(ButtonPressed), new Godot.Collections.Array() { (item) });
            }
        }
        static public TitleCard GetInstance()
        {
            if (instance == null) instance = new TitleCard();
            return instance;
        }

        private void ButtonPressed(Button pButton)
        {
            switch (pButton.Name)
            {
                case StrManager.PARAMETERS:
                    return;
                case StrManager.PLAY:
                    break;
                case StrManager.QUIT:
                    return;
                case StrManager.CREDIT:
                    return;
                default:
                    break;
            }
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
        }
    }

}