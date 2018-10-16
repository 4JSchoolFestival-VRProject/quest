using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagica : MonoBehaviour
{

    [SerializeField]
    private GameObject magicaPrefabs;
    [SerializeField]
    private OVRCameraRig mycamera;
    private Transform x;
    float span = 4.0f;
    float delta = 0;

    void Start()
    {
        x = mycamera.transform;
        mycamera = transform.parent.gameObject.GetComponent<OVRCameraRig>();
    }

    public void ShotMagica()
    {

        Instantiate(magicaPrefabs, x);
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