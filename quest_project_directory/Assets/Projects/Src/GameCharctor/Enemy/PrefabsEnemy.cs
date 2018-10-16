using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PrefabsEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private GameObject cube;
    private EnemyAnimator ea;
    Vector3 v;
    NavMeshAgent agent;
    float min_dis;
    static bool flag;

    void Start()
    {
        flag = false;
        min_dis = 3.5f;
        agent = GetComponent<NavMeshAgent>();
        v = agent.velocity;
        ea = GetComponent<EnemyAnimator>();
        cube = GameObject.Find("PlayerPhisic");
    }

    void Update()
    {
        Vector3 p = transform.position;
        Vector3 l = cube.transform.position;
        float dis = Vector3.Distance(p, l);
        Debug.Log(dis);
        if (dis > min_dis) {
            agent.destination = target.transform.position;
            Debug.Log("まだいける");
        }
        else if (agent.isStopped == false) {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                ea.Attack(true);
                Debug.Log("もう無理");
            
        }
        else if(flag)
        {
            ea.Attack(false);
            ea.Walk(true);
            agent.isStopped = true;
            agent.velocity = -3 * v;
        }
    }

    public static void Flag(bool value)
    {
        flag = value;
    }
}
