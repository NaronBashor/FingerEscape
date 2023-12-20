using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private int shieldCount;
        [SerializeField] private float shieldTimer;
        [SerializeField] private UnityEngine.UI.Image fillImage;

        [SerializeField] private TextMeshProUGUI shieldCountText;

        private bool shieldActive = false;

        public int ShieldCount
        {
                get => shieldCount;
                set => shieldCount=value;
        }
        public bool ShieldActive
        {
                get => shieldActive;
                set => shieldActive=value;
        }

        public void LoadData(GameData data)
        {
                this.shieldCount = data.shieldTotal;
        }

        public void SaveData(ref GameData data)
        {
                data.shieldTotal = this.shieldCount;
        }

        private void Update()
        {
                shieldCountText.text = "x" + shieldCount.ToString();
                fillImage.fillAmount = shieldTimer;
                if (shieldActive)
                {
                        shieldTimer += Time.deltaTime / 5;
                }
                if (shieldTimer >= 1)
                {
                        shieldActive = false;
                        shieldTimer = 0;
                }
        }

        public void UseShield()
        {
                shieldCount--;
        }
}
