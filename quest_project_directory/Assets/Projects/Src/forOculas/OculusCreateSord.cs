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

        Debug.Log("aa");
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
        /*
            if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                obj.SetActive(false);
            }
            */

        }
        else return;
        
    }
/*
    public void CreatePrefabsSord()
    {
        Vector3 v = new Vector3(0.2f, 2.8f, 0.5f);
        Quaternion rote = new Quaternion(220.0f, -0.5f, 0.0f, 1.0f);
        //    this.obj = Instantiate(sordprefabs, v, Quaternion.identity) as GameObject;
        obj = Instantiate(sordprefabs) as GameObject;
        OnParentChange();

    }
    */
    public void OnParentChange()
    {
        Obj.transform.parent = parenthand;
        Debug.Log(parenthand);
        Debug.Log(gameObject.transform.parent.gameObject.name);
    }
}

