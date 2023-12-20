using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private TextMeshProUGUI coinTotalText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private int highScore;
        private int coinTotal;

        public void LoadData(GameData data)
        {
                this.coinTotal = data.coinTotal;
                this.highScore = data.highScore;
        }

        public void SaveData(ref GameData data)
        {
                data.coinTotal = this.coinTotal;
                data.highScore = this.highScore;
        }

        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();
        }

        private void Update()
        {
                highScoreText.text = "High Score: " + "\n" + highScore.ToString();
                coinTotalText.text = "Coins: " + "\n" + coinTotal.ToString();
        }
}
