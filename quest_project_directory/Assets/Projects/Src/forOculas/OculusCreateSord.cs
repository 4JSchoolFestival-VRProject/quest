using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusCreateSord: MonoBehaviour {

    private Transform parenthand;
    [SerializeField]
    private GameObject obj;
    private bool flag;
    
    // Use this for initialization
    void Start () {
        
        flag = true;

    }

    public GameObject Obj { get; private set; }

    
    // Update is called once per frame
    void Update () {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            obj.SetActive(true);
            flag = false;

        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            obj.SetActive(false);
        

        }
        else return;
        
    }

    public void OnParentChange()
    {
        Obj.transform.parent = parenthand;
        Debug.Log(parenthand);
        Debug.Log(gameObject.transform.parent.gameObject.name);
    }
}

