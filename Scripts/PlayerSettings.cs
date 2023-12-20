using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        private float musicVolume;
        private float soundVolume;

        public List<GameObject> splatterColors = new List<GameObject>();

        private void Start()
        {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
                soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        }

        private void Update()
        {
                musicVolume = musicSlider.value;
                soundVolume = soundSlider.value;
                PlayerPrefs.SetFloat("MusicVolume" , musicVolume);
                PlayerPrefs.SetFloat("SoundVolume" , soundVolume);
        }
}
