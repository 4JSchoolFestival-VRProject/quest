using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusKeyBind : MonoBehaviour {

    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject obj2;
    [SerializeField]
    private GameObject gui;
    private bool flag_ontrigger;
	// Use this for initialization
	void Start () {
        gui.SetActive(false);
        obj.SetActive(false);
        obj2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            flag_ontrigger = true;
            gui.SetActive(true);
            obj.SetActive(true);
            obj2.SetActive(true);
        }
        
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            gui.SetActive(false);
            obj.SetActive(false);
            obj2.SetActive(false);
        }
        
        
    }
}
