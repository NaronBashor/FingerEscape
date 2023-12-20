using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private Button coinPurchaseButton;
        [SerializeField] private Button inAppPurchaseButton;

        [SerializeField] private TextMeshProUGUI coinTotalText;

        private int coinTotal;
        private int shieldTotal;

        public void LoadData(GameData data)
        {
                this.coinTotal = data.coinTotal;
                this.shieldTotal = data.shieldTotal;
        }

        public void SaveData(ref GameData data)
        {
                data.coinTotal = this.coinTotal;
                data.shieldTotal = this.shieldTotal;
        }

        private void Update()
        {
                coinTotalText.text = coinTotal.ToString();
        }

        public void Purchase500Coins()
        {
                coinTotal += 500;
        }

        public void PurchaseShields()
        {
                shieldTotal += 3;
        }
}
