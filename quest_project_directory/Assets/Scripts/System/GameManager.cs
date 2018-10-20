using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Custom
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager singleton;
        public static StartCountDown startCountDown;
        public List<Stage> stages = new List<Stage>();
        public int stageNum = 0;

        private void Awake()
        {
            if (singleton != null)
            {
                Destroy(gameObject);
                return;
            }
            singleton = this;
        }

        private void Start()
        {
            SceneManager.activeSceneChanged += OnSceneLoaded;
        }

        private void Update()
        {
            /*
            if ()
            {

            }
            */
        }

        public void OnSceneLoaded(Scene bscene, Scene ascene)
        {
            Debug.Log("OnSceneLoaded : " + ascene.name);
            switch (ascene.name)
            {
                case "Title":
                    break;

                case "Encount":
                    //PlayerController.singleton.UpdateStatus(1, 40, true);
                    //Playeropntroller.singleton.UpdateStatus(1, 40, false);
                    startCountDown.GameStartAction = OnStartGame;
                    startCountDown.CountDown();
                    break;
                case "gameover":
                    break;
            }
        }

        private void OnStartGame()
        {
            Debug.Log("Start");
            EnemySpawner.singleton.EnemyPrefabs = stages[stageNum].EnemyPrefabs;
        }
    }
}