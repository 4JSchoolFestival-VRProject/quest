using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusSordCollider : MonoBehaviour {

    [SerializeField]
    private GameObject particleprefabs;

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider collision)
    {
        string str = collision.gameObject.tag;
        switch(str)
        {
            case "Enemy":
                Enemy e = GameObject.FindGameObjectWithTag(str).GetComponent<Enemy>();
                e.processBattleEvent();
                if (e.Hp <= 0) Destroy(collision.gameObject);
                PrefabsEnemy.Flag(true);
                break;
            case "Magica":
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
