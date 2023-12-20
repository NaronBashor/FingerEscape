using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectScroller : MonoBehaviour
{
        [SerializeField] private float moveSpeed;

        private void Update()
        {
                // Have instantiated prefab find the bool
                bool enemySpawner = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>().GamePlaying;

                // Check is game is currently started and playing
                if (enemySpawner)
                {
                        // Move any object this is attached to downward
                        float multiplier = GameObject.Find("LevelProgressionMultiplier").GetComponent<LevelProgress>().Multiplier;
                        this.transform.position += new Vector3(0 , ((moveSpeed - 0.01f) * (multiplier * 2)));
                }
        }
}
