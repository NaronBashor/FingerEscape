using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DotSpawn : MonoBehaviour
{
        [SerializeField] private GameObject dot;

        [SerializeField] private float spawnDelay;
        [SerializeField] private GameObject enemySpawner;

        private bool start = false;

        private void Update()
        {
                if (enemySpawner.GetComponent<EnemySpawner>().GamePlaying)
                {
                        // If delay timer runs out then start spawning in the dots
                        if (!start)
                        {
                                spawnDelay -= Time.deltaTime;
                        }

                        if (spawnDelay <= 0 && !start)
                        {
                                start = true;
                                SpawnDot();
                        }
                }
        }

        public void SpawnDot()
        {
                // Spawn in dot within screen size
                float randomX = Random.Range(-2 , 9);
                float randomY = Random.Range(-11 , 7);
                Vector2 spawn = new Vector2(randomX , randomY);
                Instantiate(dot , spawn , Quaternion.identity);
        }
}
