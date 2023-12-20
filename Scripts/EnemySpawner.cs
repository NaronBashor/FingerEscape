using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour, IDataPersistence
{
        public List<GameObject> enemies = new List<GameObject>();
        public List<Transform> spawnLocations = new List<Transform>();
        public List<Transform> startupSpawnLocations = new List<Transform>();
        public List<int> availableSpawns = new List<int>();
        public List<int> pickedSpawns = new List<int>();

        [SerializeField] private GameObject coin;
        [SerializeField] private GameObject deathSplat;
        [SerializeField] private float initialTimer;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject startLevelTimer;

        [SerializeField] private AudioSource splatSound;
        [SerializeField] private AudioSource deathSound;

        private int randomEnemy;
        private int randomSpawn;

        private int coinTotal;

        private float timer;
        private float coinProb;

        private bool deathSoundPlayed = false;
        private bool death = false;

        private bool spawnCoin = false;
        private bool gamePlaying;
        private bool gameOver = false;

        public bool GamePlaying
        {
                get => gamePlaying;
                set => gamePlaying=value;
        }
        public bool GameOver
        {
                get => gameOver;
                set => gameOver=value;
        }
        public float InitialTimer
        {
                get => initialTimer;
                set => initialTimer=value;
        }

        public void LoadData(GameData data)
        {
                this.coinTotal=data.coinTotal;
        }

        public void SaveData(ref GameData data)
        {
                this.coinTotal=data.coinTotal;
                
        }

        private void Start()
        {
                InitializeNumbers();
                startPanel.SetActive(true);
                gameOverPanel?.SetActive(false);
                GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<LevelMusic>().PlayMusic();
                splatSound.volume = PlayerPrefs.GetFloat("SoundVolume");
                deathSound.volume = PlayerPrefs.GetFloat("SoundVolume");
        }

        private void Update()
        {
                if (!gameOver)
                {
                        if (Input.GetMouseButtonDown(0))
                        {
                                gamePlaying = true;
                                StartUpSpawn();
                                startPanel.SetActive(false);
                                startLevelTimer.GetComponent<LevelProgress>().Start = true;
                        }
                        else if (Input.GetMouseButtonUp(0))
                        {
                                if (!deathSoundPlayed)
                                {
                                        deathSoundPlayed = true;
                                        deathSound.Play();
                                }
                                if (!death)
                                {
                                        death = true;
                                        splatSound.Play();
                                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                        Instantiate(deathSplat , new Vector3(mousePos.x , mousePos.y , -10) , Quaternion.identity);
                                }
                                gameOver = true;
                                gamePlaying = false;
                                gameOverPanel?.SetActive(true);
                        }
                }
                if (gameOver || GameObject.Find("LevelProgressionMultiplier").GetComponent<LevelProgress>().GameOver)
                {
                        if (!death)
                        {
                                death = true;
                                splatSound.Play();
                                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                Instantiate(deathSplat , new Vector3(mousePos.x , mousePos.y , -10) , Quaternion.identity);
                        }
                        if (!deathSoundPlayed)
                        {
                                deathSoundPlayed = true;
                                deathSound.Play();
                        }
                        gamePlaying = false;
                        gameOverPanel?.SetActive(true);
                        if (Input.GetMouseButtonDown(0))
                        {
                                GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<LevelMusic>().StopMusic();
                                SceneManager.LoadScene("MainMenu");
                        }
                }

                // If timer reaches 0 then spawn in a random enemy to a random position
                if (GamePlaying)
                {
                        if (timer <= 0)
                        {
                                coinProb = Random.Range(0 , 101);
                                if (coinProb > 90)
                                {
                                        spawnCoin = true;
                                }
                                int number;
                                timer = InitialTimer;
                                randomEnemy = Random.Range(0 , enemies.Count);
                                randomSpawn = PickRandomUniqueNumber();
                                if (spawnCoin)
                                {
                                        spawnCoin = false;
                                        if (randomSpawn + 1 > 3)
                                        {
                                                number = 0;
                                        }
                                        else
                                        {
                                                number = randomSpawn + 1;
                                        }
                                        Instantiate(coin , spawnLocations[number].position , Quaternion.identity);
                                }
                                Instantiate(enemies[randomEnemy] , spawnLocations[randomSpawn].position , Quaternion.identity);
                        }

                        //  Reset timer
                        timer -= Time.deltaTime;
                }
        }

        public void StartUpSpawn()
        {
                for (int i = 0; i < startupSpawnLocations.Count; i++)
                {
                        int randomNumber = Random.Range(0 , enemies.Count);
                        Instantiate(enemies[randomNumber] , startupSpawnLocations[i].position , Quaternion.identity);
                }
        }

        public void InitializeNumbers()
        {
                // Set the list with starting numbers
                for (int i = 0; i < spawnLocations.Count; i++)
                {
                        availableSpawns.Add(i);
                }
        }

        public int PickRandomUniqueNumber()
        {
                // If list is not empty then pick an int and remove it after
                if (availableSpawns.Count == 0)
                {
                        ResetNumbers();
                }

                int randomIndex = Random.Range(0 , availableSpawns.Count);
                int pickedSpawn = availableSpawns[randomIndex];
                availableSpawns.RemoveAt(randomIndex);

                return pickedSpawn;
        }

        public void ResetNumbers()
        {
                // If list is empty reset it and clear picked numbers
                InitializeNumbers();

                pickedSpawns.Clear();
        }
}
