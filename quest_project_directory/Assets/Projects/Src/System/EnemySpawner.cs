using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> EnemyPrefabs = new List<GameObject>();

    private int EnemyCount = 0;
    private int KilledEnemyCount = 0;

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
            Spawn(0);
            yield return new WaitForSeconds(5.0f);
        }
    }

    private void Spawn(int enemyNum)
    {
        float r = Random.Range(0.0f, 360.0f);
        Vector3 spawnPos = Vector3.forward * Mathf.Cos(r) + Vector3.forward * Mathf.Sin(r) * 20.0f;
        GameObject obj = Instantiate(EnemyPrefabs[enemyNum], spawnPos, Quaternion.identity);
        obj.transform.LookAt(Vector3.zero);
        EnemyCount++;
    }
}
