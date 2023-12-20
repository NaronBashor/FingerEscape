using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
        [SerializeField] private AudioSource menuMusic;
        [SerializeField] private AudioSource buttonSound;

        private void Awake()
        {
                DontDestroyOnLoad(this);
                menuMusic = GetComponent<AudioSource>();

                menuMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
                buttonSound.volume = PlayerPrefs.GetFloat("SoundVolume");
        }

        public void PlayMusic()
        {
                if (menuMusic.isPlaying)
                {
                        return;
                }
                else if (!menuMusic.isPlaying)
                {
                        menuMusic.Play();
                }
        }

        public void StopMusic()
        {
                menuMusic.Stop();
        }

        public void ButtonSound()
        {
                buttonSound.Play();
        }

        private void Update()
        {
                menuMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
                buttonSound.volume = PlayerPrefs.GetFloat("SoundVolume");
        }
}
