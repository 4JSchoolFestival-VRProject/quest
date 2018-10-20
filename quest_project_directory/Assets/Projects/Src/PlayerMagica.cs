using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagica : MonoBehaviour
{

    [SerializeField]
    private GameObject magicaPrefabs;
    [SerializeField]
    public Transform muzzle;
    public float speed = 1.0f;

    float span = 4.0f;
    float delta = 0;

    void Start()
    {
       
    }

    public void ShotMagica()
    {

        GameObject magic =  Instantiate(magicaPrefabs,muzzle.position, muzzle.rotation) as GameObject;
        Vector3 force;

        force = magic.transform.forward * speed;

        // Rigidbodyに力を加えて発射
       magic.GetComponent<Rigidbody>().AddForce(force);
    }

    void Update()
    { 
        //OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)

        /*
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            Destroy(gameObject);
        }
        */
    }
}