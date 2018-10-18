using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusSordCollider : MonoBehaviour {

    [SerializeField]
    private GameObject particleprefabs;
    private SoundManager s;
    private Player p;

    void Start()
    {
        s = GetComponent<SoundManager>();
    }

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider collision)
    {
        p = myDataBase.AgentPlayer();
        string str = collision.gameObject.tag;
        switch(str)
        {
            
            case "Ax":
                s.Sound(0);
                Debug.Log("がっキーン");
                break;
            case "Enemy":
                s.Sound(1);
                Enemy e = GameObject.FindGameObjectWithTag(str).GetComponent<Enemy>();
                e.processDefenceEvent(p.processBattleEvent(), true);
                PrefabsEnemy.Flag(true);
                break;
            case "Magica":
                s.Sound(2);
                GameObject particle = Instantiate(particleprefabs) as GameObject;
                Vector3 hitPos = collision.ClosestPointOnBounds(this.transform.position);
                particle.transform.position = hitPos;
                Destroy(collision.gameObject);
                break;
            default:
                Debug.Log("何に当たったか分からないよ～");
                break;


        }
       
    }

    //オブジェクトが離れた時
    void OnTriggerStay(Collider collision)
    {
        Debug.Log("いま離れちゃいました.");

    }

    //オブジェクトが触れている間
    void OnTriggerExit(Collider collision)
    {
        Debug.Log("離れていますよ.");
    }

}
