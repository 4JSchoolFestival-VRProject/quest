using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashTrail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenpointer = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 1.0f);
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(screenpointer);
	}
}
