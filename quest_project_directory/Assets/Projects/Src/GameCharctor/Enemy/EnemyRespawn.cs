using UnityEngine;
using System.Collections.Generic;

public class EnemyRespawn : MonoBehaviour
{ 
    //private int 
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int how_is_enemy = 3;
    private static bool flag;
    private List<GameObject> enemy_collection;
        

    public bool isEnemyDead()
    {
        if (flag) return SceneBack.F_Scene = true; 
        return SceneBack.F_Scene = false;
    }

    void Start()
    {
        flag = false;
        enemy_collection = new List<GameObject>();
        GameObject g;
        for (int i = 0; i < how_is_enemy; i++)
        {
            g = Instantiate(enemy,
                            new Vector3((i * 15) - 10, 1, 25),
                            Quaternion.identity) as GameObject;
           // Debug.Log(i);
            enemy_collection.Add(g);
        }
    }

    void Update()
    {
        
    }
}

