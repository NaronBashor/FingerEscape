using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
        [SerializeField] private float multiplier = 1;
        [SerializeField] private float levelTimer = 60;

        [SerializeField] private Image slider;

        [SerializeField] private TextMeshProUGUI levelTimerText;

        private float timer = 10;
        private bool start = false;
        private bool gameOver = false;

        public float Multiplier
        {
                get => multiplier;
                set => multiplier=value;
        }
        public bool Start
        {
                get => start;
                set => start=value;
        }
        public bool GameOver
        {
                get => gameOver;
                set => gameOver=value;
        }

        private void Update()
        {
                levelTimerText.text = ((int)levelTimer).ToString();
                slider.fillAmount = levelTimer / 60;
                if (levelTimer <= 0)
                {
                        gameOver = true;
                }
                if (start && !gameOver)
                {
                        levelTimer -= Time.deltaTime;
                        timer -= Time.deltaTime;
                        if (timer <= 0)
                        {
                                timer = 10;
                                multiplier += 1f;
                                GameObject.Find("SpawnManager").GetComponent<EnemySpawner>().InitialTimer *= 0.75f;
                        }
                }
        }
}
