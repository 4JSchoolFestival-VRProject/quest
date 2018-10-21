using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner singleton;

    public List<GameObject> EnemyPrefabs = new List<GameObject>();
    public List<GameObject> enemyList = new List<GameObject>();

    public float span = 5.0f;
    public float noruma = 5;
    public int spawnLevel = 1;
    public int EnemyCount = 0;
    public int KilledEnemyCount = 0;
    public int spawndEnemy = 0;


    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {

    }
    
    public void StartSpawn()
    {
        EnemyCount = 0;
        KilledEnemyCount = 0;
        spawndEnemy = 0;
        foreach(GameObject obj in enemyList)
        {
            if (obj != null)
                Destroy(obj);
        }
        enemyList.Clear();

        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn()
    {
        Debug.Log("LoopSpawn");
        while (true)
        {
            if (spawndEnemy < noruma)
            {
                int n = Random.Range(0, EnemyPrefabs.Count);
                Spawn(n);
            }
            else
            {
                yield break;
            }
            yield return new WaitForSeconds(span);
        }
    }

    private void Spawn(int enemyNum)
    {
        float r = Random.Range(0.0f, 360.0f);
        Vector3 spawnPos = PlayerController.singleton.transform.position + (Vector3.right * Mathf.Cos(r) + Vector3.forward * Mathf.Sin(r)) * 20.0f;
        EnemyPrefabs[enemyNum].GetComponent<EnemyController>().spawnLevel = spawnLevel;
        GameObject obj = Instantiate(EnemyPrefabs[enemyNum], spawnPos, Quaternion.identity);
        obj.transform.LookAt(PlayerController.singleton.transform.position);
        EnemyCount++;
        spawndEnemy++;
        enemyList.Add(obj);
    }

    public void DeathEnemy()
    {
        EnemyCount--;
        KilledEnemyCount++;
    }
}
