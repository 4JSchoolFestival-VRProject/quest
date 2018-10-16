using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR : MonoBehaviour {

    //レンダリングパフォーマンスを調整するためのスクリプト
    public class VRDeviceManager : MonoBehaviour
    {

        [SerializeField] private float m_RenderScale = 1.4f;
        private static VRDeviceManager s_Instance;

        public static VRDeviceManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = FindObjectOfType<VRDeviceManager>();
                    //新しいシーンを読み込んでもオブジェクトが自動で破壊されないように登録
                    DontDestroyOnLoad(s_Instance.gameObject);
                }
                return s_Instance;
            }
        }

        private void Awake()
        {
            if (s_Instance == null)
            {
                s_Instance = this;
                DontDestroyOnLoad(this);
            }
            else if (this != s_Instance)
            {
                Destroy(gameObject);
            }
        }

    }
}
