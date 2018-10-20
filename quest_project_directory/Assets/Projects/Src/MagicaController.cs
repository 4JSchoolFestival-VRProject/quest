using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicaController : MonoBehaviour
{

    public float speed = -0.3f;
    public float rotMax = 1.0f;
    public float timeOut;
    private float timeElapsed;
    private Transform target;

    void Start()
    {
        target = Player.singleton.transform;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        Vector3 vec = target.position + transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotMax);
        transform.Translate(Vector3.forward * speed);
        if (timeElapsed >= timeOut)
        {
            Destroy(gameObject);
            timeElapsed = 0.0f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        string str = other.gameObject.tag;
        if(str == "Sord")
        {
            timeElapsed = 0;
        }
    }
}
