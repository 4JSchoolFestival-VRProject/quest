using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class VRenable : MonoBehaviour {

    public class ToggleVR : MonoBehaviour
    {
        // VRSettings の有効/無効を切り替えるサンプル
        private void Update()
        {
            // Vキーを押したときに VRSettings.enabled が切り替わります。
            if (Input.GetKeyDown(KeyCode.V))
            {
                XRSettings.enabled = !XRSettings.enabled;
                Debug.Log("VRSettings.enabled が" + XRSettings.enabled + "に切り替わりました。");
            }
        }
    }
}
