using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PrefabsEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private GameObject cube;
    NavMeshAgent agent;
    float min_dis;

    void Start()
    {
        min_dis = 4.0f;
        agent = GetComponent<NavMeshAgent>();
        cube = GameObject.Find("PlayerPhisic");
    }

    void Update()
    {
        Vector3 p = transform.position;
        Vector3 l = cube.transform.position;
        float dis = Vector3.Distance(p, l);
        Debug.Log(dis);
        if (dis > min_dis) { agent.destination = target.transform.position; Debug.Log("まだいける"); }
        else if (agent.isStopped == false) { agent.isStopped = true; agent.velocity = Vector3.zero; Debug.Log("もう無理"); }
        else return;
    }
}
