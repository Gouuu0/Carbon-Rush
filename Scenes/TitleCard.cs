using Godot;
using System;
using System.Collections.Generic;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Manager {

	public class TitleCard : Node2D
	{
        static private TitleCard instance;

        [Export] private NodePath playPath;
        Button play;
        [Export] private NodePath quitPath;
        Button quit;
        [Export] private NodePath parameterPath;
        Button parameter;
        [Export] private NodePath creditPath;
        Button credit;

        [Export] PackedScene parameterScene;

        public override void _Ready()
        {
            play = (Button)GetNode(playPath);
            quit = (Button)GetNode(quitPath);
            parameter = (Button)GetNode(parameterPath);
            credit = (Button)GetNode(creditPath);

            LgManager.TranslateAdd(play, StrManager.playList);
            LgManager.TranslateAdd(quit, StrManager.quitList);
            LgManager.TranslateAdd(credit, StrManager.creditList);
            LgManager.TranslateAdd(parameter, StrManager.parameterList);

            play.Connect(StrManager.PRESSED, this, nameof(Play));
            quit.Connect(StrManager.PRESSED, this, nameof(Quit));
            parameter.Connect(StrManager.PRESSED, this, nameof(Parameter));
            credit.Connect(StrManager.PRESSED, this, nameof(Credit));

            instance = null;
            if (instance != null)
            {
                QueueFree();
            }
            instance = this;

            SoundManager.GetInstance().PlayMusic(StrManager.MUSIC);
        }
        static public TitleCard GetInstance()
        {
            if (instance == null) instance = new TitleCard();
            return instance;
        }

        private void Play()
        {
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
        }
        private void Quit()
        {
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
            GetTree().Quit();
        }
        private void Credit()
        {
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
        }
        private void Parameter()
        {
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
            Node2D lPar = parameterScene.Instance() as Node2D;
            AddChild(lPar);
        }
    }

}