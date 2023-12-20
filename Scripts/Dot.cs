using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
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
                        // If touched then destroy this dot and spawn a new one and add to score
                        GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<LevelMusic>().DotCollectSound();
                        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().CurrentScore++;
                        GameObject.Find("DotSpawn").GetComponent<DotSpawn>().SpawnDot();
                        Destroy(this.gameObject);
                }
        }
}
