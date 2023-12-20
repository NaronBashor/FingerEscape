using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
        private void OnMouseEnter()
        {
                if (!GameObject.Find("ShieldManager").GetComponent<ShieldManager>().ShieldActive)
                {
                        if (GameObject.Find("ShieldManager").GetComponent<ShieldManager>().ShieldCount > 0)
                        {
                                GameObject.Find("ShieldManager").GetComponent<ShieldManager>().UseShield();
                                GameObject.Find("ShieldManager").GetComponent<ShieldManager>().ShieldActive = true;
                        }
                        else if (GameObject.Find("ShieldManager").GetComponent<ShieldManager>().ShieldCount <= 0)
                        {
                                GameObject enemySpawner = GameObject.Find("SpawnManager");
                                enemySpawner.GetComponent<EnemySpawner>().GameOver = true;
                                enemySpawner.GetComponent<EnemySpawner>().GamePlaying = false;
                        }
                }
        }
}
