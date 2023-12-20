using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
        [SerializeField] private AudioSource levelMusic;
        [SerializeField] private AudioSource dotCollect;

        private void Awake()
        {
                DontDestroyOnLoad(this);
                levelMusic = GetComponent<AudioSource>();
                GameObject.Find("MenuMusic").GetComponent<MenuMusic>().StopMusic();
                levelMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
                dotCollect.volume = PlayerPrefs.GetFloat("SoundVolume");
        }

        public void PlayMusic()
        {
                if (levelMusic.isPlaying)
                {
                        return;
                }
                levelMusic.Play();
        }

        public void StopMusic()
        {
                levelMusic.Stop();
        }

        public void DotCollectSound()
        {
                dotCollect.Play();
        }

        private void Update()
        {
                levelMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
                dotCollect.volume = PlayerPrefs.GetFloat("SoundVolume");
        }
}
