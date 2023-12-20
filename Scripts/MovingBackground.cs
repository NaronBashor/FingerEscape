using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour
{
        [SerializeField] private Image background;
        [SerializeField] private float moveSpeed;

        [SerializeField] private GameObject enemySpawner;

        private void Update()
        {
                // Check is game is currently started and playing
                if (enemySpawner != null)
                {
                        if (enemySpawner.GetComponent<EnemySpawner>().GamePlaying)
                        {
                                //  Move background downward
                                float multiplier = GameObject.Find("LevelProgressionMultiplier").GetComponent<LevelProgress>().Multiplier;

                                background.rectTransform.transform.position += new Vector3(0 , ((moveSpeed - 0.01f) * (multiplier * 2)));
                        }
                }
        }
}
