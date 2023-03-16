using Godot;
using System;
using System.Collections.Generic;
using Com.IsartDigital.Manager;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Manager
{

    public class SoundManager : Node2D
    {
        [Export] private int musicPlayerNumber = 2;

        [Export]
        public Dictionary<string, AudioStreamOGGVorbis> sfxDictionary = new Dictionary<string, AudioStreamOGGVorbis>()
        { {StrManager.CAR_KEYS, default},
        {StrManager.DOOR_CLOSE, default},
        {StrManager.DOOR_OPEN, default},
        {StrManager.FAMILY_FOOTSTEP_A, default},
        {StrManager.FAMILY_FOOTSTEP_B, default},
        {StrManager.FAUCET_OPEN, default},
        {StrManager.FAUCET_CLOSE, default},
        {StrManager.FRIDGE_OPEN, default},
        {StrManager.FRIDGE_CLOSE, default},
        {StrManager.HEATER_OFF, default},
        {StrManager.HEATER_ON, default},
        {StrManager.LIGHT_OFF, default},
        {StrManager.LIGHT_ON, default},
        {StrManager.MENU_CLICK, default},
        {StrManager.O2_ALMOST_FULL, default},
        {StrManager.PLAYER_SPOTTED, default},
        {StrManager.TV_STATIC, default},
        {StrManager.TV_OFF, default},
        {StrManager.WINDOW_CLOSE, default},
        {StrManager.WINDOW_OPEN, default}};

        [Export]
        public Dictionary<string, AudioStreamOGGVorbis> musicDictionary = new Dictionary<string, AudioStreamOGGVorbis>()
        { {StrManager.AMBIANCE, default},
        {StrManager.MUSIC, default} };

        private List<AudioStreamPlayer> sfxPlayerList = new List<AudioStreamPlayer>();
        private List<AudioStreamPlayer> musicPlayerList = new List<AudioStreamPlayer>();
        static private SoundManager instance;

        private bool isMusicOn;
        private bool isSfxOn;

        private float startVolumeSfx;
        private float startVolumeMusic;
        private const float MUTE = -80;

        public override void _Ready()
        {
            foreach (AudioStreamPlayer item in GetChildren()) sfxPlayerList.Add(item);
            MusicListAssignation(musicPlayerNumber);

            instance = null;
            if (instance != null)
            {
                QueueFree();
                return;
            }
            instance = this;
            startVolumeMusic = musicPlayerList[0].VolumeDb;
            startVolumeSfx = sfxPlayerList[0].VolumeDb;
        }

        static public SoundManager GetInstance()
        {
            if (instance == null) instance = new SoundManager();
            return instance;
        }

        public void ToggleMusic()
        {
            if (isMusicOn) StopMusic();
            else
            {
                isMusicOn = true;
                foreach (AudioStreamPlayer item in musicPlayerList) item.VolumeDb = startVolumeMusic;
            }
        }

        public void ToggleSFX()
        {
            if (isSfxOn) StopSFX();
            else
            {
                isSfxOn = true;
                foreach (AudioStreamPlayer item in sfxPlayerList) item.VolumeDb = startVolumeSfx;
            }
        }

        public void PlayMusic(string pString)
        {
            foreach (AudioStreamPlayer item in musicPlayerList)
            {
                if (!item.Playing)
                {
                    item.Stream = sfxDictionary[pString];
                    sfxDictionary[pString].Loop = true;
                    item.Play();
                }
            }
        }

        private void StopMusic()
        {
            foreach (AudioStreamPlayer item in musicPlayerList)
            {
                item.VolumeDb = MUTE;
                item.Stop();
            }
            isMusicOn = false;
        }

        private void StopSFX()
        {
            foreach (AudioStreamPlayer item in sfxPlayerList)
            {
                item.VolumeDb = MUTE;
                item.Stop();
            }
            isSfxOn = false;
        }

        public void PlaySFX(string pString)
        {
            bool lIsPlaying = false;
            foreach (AudioStreamPlayer item in sfxPlayerList)
            {
                if (!item.Playing && !lIsPlaying)
                {
                    lIsPlaying = true;
                    item.Stream = sfxDictionary[pString];
                    sfxDictionary[pString].Loop = false;
                    item.Play();
                }
            }
        }
        public void ModulateSFX(double pDouble)
        {
            startVolumeSfx = (float)pDouble;
            foreach (AudioStreamPlayer item in sfxPlayerList)
            {
                item.VolumeDb = startVolumeSfx;
            }
        }

        public void ModulateMusic(double pDouble)
        {
            startVolumeMusic = (float)pDouble;
            foreach (AudioStreamPlayer item in musicPlayerList)
            {
                item.VolumeDb = startVolumeMusic;
            }
        }

        private void MusicListAssignation(int pInt)
        {
            for (int i = 0; i < pInt; i++)
            {
                musicPlayerList.Add(sfxPlayerList[sfxPlayerList.Count - 1]);
                sfxPlayerList.RemoveAt(sfxPlayerList.Count - 1);
            }
        }

        public void ClearMusicPlayers()
        {
            foreach (AudioStreamPlayer item in musicPlayerList) item.Stop();
        }

        public void ClearSFXPlayers()
        {
            foreach (AudioStreamPlayer item in sfxPlayerList) item.Stop();
        }

        public void ClearAllPlayers()
        {
            ClearMusicPlayers();
            ClearSFXPlayers();
        }
    }
}