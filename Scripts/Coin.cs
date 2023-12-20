using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
        private bool isPlaying = false;

        private void Update()
        {
                isPlaying = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>().GamePlaying;
        }

        private void OnMouseEnter()
        {
                if (isPlaying)
                {
                        // Find coin counter and add one to the count
                        GameObject.Find("CoinManager").GetComponent<CoinManager>().CoinCount++;
                        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().CurrentScore += 100;
                        Destroy(this.gameObject);
                }
        }
}
