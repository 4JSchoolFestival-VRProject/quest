using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    [SerializeField]
    private GameObject particleprefabs;
    private SoundManager s;
    private Player p;

    void Start()
    {
        p = myDataBase.AgentPlayer();
        s = GetComponent<SoundManager>();
    }

    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider collision)
    {
        
        string str = collision.gameObject.tag;
        switch (str)
        { 
            case "Ax":
                s.Sound(0);
                p.processHpEvent(5);
                break;
            case "Enemy":
         //       Debug.Log("敵が攻撃してきた");;
                break;
            case "Magica":
                s.Sound(0);
                GameObject particle = Instantiate(particleprefabs) as GameObject;
                Vector3 hitPos = collision.ClosestPointOnBounds(this.transform.position);
                particle.transform.position = hitPos;
                Destroy(collision.gameObject);
                p.processHpEvent(2);
                Debug.Log("魔法攻撃とは小癪な");
                break;
            default:
                Debug.Log("何に当たったか分からないよ～");
                break;


        }
       // if(p.Search(2) <= 0)

    }

    // Update is called once per frame
    void Update () {
		
	}
}
