using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicaController : MonoBehaviour {
    public float advanceBullet = -0.3f;
   
    void Update()
    {
        
        transform.Translate(0, 0, this.advanceBullet);
        if (transform.position.z < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
