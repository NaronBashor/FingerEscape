using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
        [SerializeField] private bool initializeDataIfNull = false;

        [SerializeField] private string fileName;
        [SerializeField] private bool useEncryption;

        private GameData gameData;

        private List<IDataPersistence> dataPersistenceObjects;
        private FileDatahandler datahandler;

        public static DataPersistenceManager Instance
        {
                get; private set;
        }

        private void Awake()
        {
                if (Instance != null)
                {
                        Destroy(this.gameObject);
                        return;
                }
                Instance = this;
                DontDestroyOnLoad(this.gameObject);

                this.datahandler = new FileDatahandler(Application.persistentDataPath, fileName, useEncryption);
        }

        private void OnEnable()
        {
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable()
        {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode0)
        {
                this.dataPersistenceObjects = FindAllDataPersistenceObjects();
                LoadGame();
        }

        public void OnSceneUnloaded(Scene scene)
        {
                SaveGame();
        }

        public void NewGame()
        {
                this.gameData = new GameData();
        }

        public void LoadGame()
        {
                this.gameData = datahandler.Load();

                if (this.gameData == null && initializeDataIfNull)
                {
                        NewGame();
                }

                if (this.gameData == null)
                {
                        Debug.LogWarning("No data was found.  A New Game needs to be started before data can be loaded.");
                        return;
                }

                foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
                {
                        dataPersistenceObj.LoadData(gameData);
                }
        }

        public void SaveGame()
        {
                if (this.gameData == null)
                {
                        Debug.LogWarning("No data was found.  A New Game needs to be started before data can be saved.");
                        return;
                }

                foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
                {
                        dataPersistenceObj.SaveData(ref gameData);
                }

                datahandler.Save(gameData);
        }

        private void OnApplicationQuit()
        {
                SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
                IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
                return new List<IDataPersistence>(dataPersistenceObjects);
        }

        public bool HasGameData()
        {
                return gameData != null;
        }
}
