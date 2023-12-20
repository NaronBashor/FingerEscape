using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
        public int highScore;
        public int totalScore;
        public int coinTotal;
        public int shieldTotal;

        public GameData()
        {
                highScore = 0;
                totalScore = 0;
                coinTotal = 0;
                shieldTotal = 0;
        }
}
