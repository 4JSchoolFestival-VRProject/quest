using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    [SerializeField] EnemyRespawn enemyRespawn;

    private void Awake()
    {
        singleton = this;
    }

    public void StartGame()
    {
        Debug.Log("Load");
        Player.singleton.UpdateStatus(1, 40, true);
        Player.singleton.UpdateStatus(1, 40, false);
        enemyRespawn.StartSpawn();
    }
}