using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusKeyBind : MonoBehaviour {

    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject obj2;
    [SerializeField]
    private GameObject m;
    private Player p;
    private PlayerMagica magica;
    private bool flag_ontrigger;
	// Use this for initialization
	void Start () {
        return;
        magica = m.GetComponent<PlayerMagica>();
      
        obj.SetActive(true);
        obj2.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        return;
        p = myDataBase.AgentPlayer();
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            obj.SetActive(false);
            obj2.SetActive(false);
        }

        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            obj.SetActive(true);
            obj2.SetActive(true);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
            {
                if (p.Search(2) <= 0) return;
                magica.ShotMagica();
                p.processMpEvent(2);

            }
        }
        
        
    }
}
