using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    private Ray ray;

    void Start()
    {
        Ray ray = new Ray(transform.position, transform.forward);
    }

    void Update()
    {
        ShotRay();
    }

    private void ShotRay()
    {
        
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.red, 3.0f);

        if (Physics.Raycast(ray, out hit, 10.0f, mask))
        {
            Debug.Log(hit.collider.gameObject);
        }
        }
}
