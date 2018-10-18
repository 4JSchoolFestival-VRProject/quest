using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagica : MonoBehaviour
{

    [SerializeField]
    private GameObject magicaPrefabs;
    [SerializeField]
    public Transform muzzle;
    public float speed = 1000;

    float span = 4.0f;
    float delta = 0;

    void Start()
    {
        
        
    }

    public void ShotMagica()
    {

        GameObject magic =  Instantiate(magicaPrefabs);
        Vector3 force;

        force = this.gameObject.transform.forward * speed;

        // Rigidbodyに力を加えて発射
       magic.GetComponent<Rigidbody>().AddForce(force);

        // 弾丸の位置を調整
       magic.transform.position = muzzle.position;
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            Destroy(gameObject);
        }

    }
}