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

        List<Button> buttonList = new List<Button>();

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
                buttonList.Add(item);
                item.Connect(StrManager.PRESSED, this, nameof(ButtonPressed));
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
                default:
                    break;
            }
        }
    }

}