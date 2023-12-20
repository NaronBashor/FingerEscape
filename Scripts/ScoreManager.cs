using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private int currentScore;

        [SerializeField] private TextMeshProUGUI currentScoreText;

        private int highScore;

        public int CurrentScore
        {
                get => currentScore;
                set => currentScore=value;
        }

        public void LoadData(GameData data)
        {
                this.highScore = data.highScore;
        }

        public void SaveData(ref GameData data)
        {
                if (this.highScore > data.highScore)
                {
                        data.highScore = this.currentScore;
                }
        }

        private void Update()
        {
                // Update score real time
                currentScoreText.text = currentScore.ToString();
                highScore = currentScore;
        }
}
