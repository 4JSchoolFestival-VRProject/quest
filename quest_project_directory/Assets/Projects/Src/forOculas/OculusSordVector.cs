using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusSordVector : MonoBehaviour {
    GameObject parent;
    OVRCameraRig cam;
    Transform hands;

	void Start () {
        parent = gameObject.transform.parent.gameObject;
        cam = parent.GetComponent<OVRCameraRig>();
    }

	void FixedUpdate(){
		if (OVRPlugin.productName == "Oculus Go") {
			var controller = OVRInput.GetActiveController() & (OVRInput.Controller.LTrackedRemote | OVRInput.Controller.RTrackedRemote);
			if (controller != OVRInput.Controller.None) {
                
                hands = cam.rightHandAnchor;
                   
				transform.Rotate (new Vector3 (hands.rotation.x, hands.rotation.y, hands.rotation.z));
			}
		}
	}
}
