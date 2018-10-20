using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner singleton;

    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    public int EnemyCount = 0;
    public int KilledEnemyCount = 0;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        GameManager.startCountDown.GameStartAction += StartSpawn;
    }
    
    private void StartSpawn()
    {
        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn()
    {
        Debug.Log("LoopSpawn");
        while(true)
        {
            int n = Random.Range(0, EnemyPrefabs.Count);
            Debug.Log(n);
            Spawn(n);
            yield return new WaitForSeconds(5.0f);
            //yield return null;
          }
    }

    private void Spawn(int enemyNum)
    {
        float r = Random.Range(0.0f, 360.0f);
        Vector3 spawnPos = Player.singleton.transform.position + (Vector3.right * Mathf.Cos(r) + Vector3.forward * Mathf.Sin(r)) * 20.0f;
        GameObject obj = Instantiate(EnemyPrefabs[enemyNum], spawnPos, Quaternion.identity);
        obj.transform.LookAt(Player.singleton.transform.position);
        EnemyCount++;
    }

    public void DeathEnemy()
    {
        EnemyCount--;
        KilledEnemyCount++;
    }
}
