using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemyRespawn enemyRespawn;

    private void Start()
    {
        SceneManager.sceneLoaded += StartGame;
    }

    private void StartGame(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Load");
    }
}