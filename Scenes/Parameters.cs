using Godot;
using System;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Manager {

	public class Parameters : Node2D
	{
        static private Parameters instance;

        [Export] private NodePath quitPath;
        Button quit;
        [Export] private NodePath sfxButtonPath;
        Button sfxButton;
        [Export] private NodePath musicButtonPath;
        Button musicButton;
        [Export] private NodePath sfxScrollPath;
        ScrollBar sfxScroll;
        [Export] private NodePath musicScrollPath;
        ScrollBar musicScroll;

        Color musicColor;
        Color sfxColor;
        public override void _Ready()
        {
            quit = (Button)GetNode(quitPath);
            sfxButton = (Button)GetNode(sfxButtonPath);
            musicButton = (Button)GetNode(musicButtonPath);
            sfxScroll = (ScrollBar)GetNode(sfxScrollPath);
            musicScroll = (ScrollBar)GetNode(musicScrollPath);

            quit.Connect(StrManager.PRESSED, this, nameof(Quit));
            sfxButton.Connect(StrManager.PRESSED, this, nameof(SFXPressed));
            musicButton.Connect(StrManager.PRESSED, this, nameof(MusicPressed));
            sfxScroll.Connect(StrManager.SCROLLING, this, nameof(SfxScroll));
            musicScroll.Connect(StrManager.SCROLLING, this, nameof(MusicScroll));

            sfxColor = sfxButton.Modulate;
            musicColor = musicButton.Modulate;
        }
        private void Quit()
        {
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
            QueueFree();
        }
        private void SFXPressed()
        {
            SoundManager.GetInstance().ToggleSFX();
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
            if (sfxButton.Modulate == Colors.DarkGray) sfxButton.Modulate = musicColor;
            else sfxButton.Modulate = Colors.DarkGray;
        }
        private void MusicPressed()
        {
            SoundManager.GetInstance().ToggleMusic();
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
            if (musicButton.Modulate == Colors.DarkGray) musicButton.Modulate = musicColor;
            else musicButton.Modulate = Colors.DarkGray;
        }
        private void SfxScroll()
        {
            SoundManager.GetInstance().ModulateSFX(sfxScroll.Value);
            SoundManager.GetInstance().PlaySFX(StrManager.MENU_CLICK);
        }
        private void MusicScroll()
        {
            SoundManager.GetInstance().ModulateMusic(musicScroll.Value);
        }
    }

}