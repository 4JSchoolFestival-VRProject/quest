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
        private EnemySpawner m_EnemySpawner;
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

            m_EnemySpawner = GetComponent<EnemySpawner>();
        }

        private IEnumerator Start()
        {
            SceneManager.activeSceneChanged += OnSceneLoaded;
            yield break;
        }

        private void Update()
        {
            Debug.Log(EnemySpawner.singleton.KilledEnemyCount + " : " + m_EnemySpawner.noruma);
            if(EnemySpawner.singleton.KilledEnemyCount >= m_EnemySpawner.noruma)
            {
                ClearStage();
            }
            if (PlayerController.singleton.status.parameters.hp <= 0)
            {
                PlayerController.singleton.ResetStatus();
                SceneManager.LoadScene("GameOver");
            }
        }

        public void OnSceneLoaded(Scene bscene, Scene ascene)
        {
            Debug.Log("OnSceneLoaded : " + ascene.name);
            switch (ascene.name)
            {
                case "Title":

                    break;

                case "Encount":
                    Debug.Log("Encount");
                    StartStage(stageNum);
                    break;
                case "GameOver":
                    break;
            }
        }

        private void OnStartGame()
        {
            Debug.Log("Start");
            StartStage(stageNum);
        }

        private void StartStage(int n)
        {
            m_EnemySpawner.EnemyPrefabs = stages[n].enemyPrefabs;
            m_EnemySpawner.span = stages[n].span;
            m_EnemySpawner.noruma = stages[n].noruma;
            m_EnemySpawner.spawnLevel = stages[n].noruma;
            startCountDown.CountDown(n);
            startCountDown.GameStartAction += m_EnemySpawner.StartSpawn;
        }

        private void ClearStage()
        {
            Debug.Log("ClearStage");
            EnemySpawner.singleton.KilledEnemyCount = 0;
            stageNum++;
            if (stageNum >= stages.Count)
            {
                stageNum = 0;
                SceneManager.LoadScene("Clear");
            }
            StartStage(stageNum);
        }
    }
}