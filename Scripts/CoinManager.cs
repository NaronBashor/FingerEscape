using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private TextMeshProUGUI coinText;

        private int coinCount;

        public int CoinCount
        {
                get => coinCount;
                set => coinCount=value;
        }

        public void LoadData(GameData data)
        {
                this.coinCount = data.coinTotal;
        }

        public void SaveData(ref GameData data)
        {
                data.coinTotal = this.coinCount;
        }

        // Update coin counter real time
        private void Update()
        {
                if (!GameObject.Find("SpawnManager").GetComponent<EnemySpawner>().GameOver)
                {
                        coinText.text = CoinCount.ToString();
                }
        }
}
