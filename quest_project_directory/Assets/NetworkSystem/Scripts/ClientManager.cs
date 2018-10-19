using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NetwrokSystem
{
    public class ClientManager : ClientSystem
    {
        [SerializeField] public int udpPort = 50000;
        [SerializeField] public int castPort = 50001;
        [SerializeField] public string iPAddress = "127.0.0.0";

        public static ClientManager singleton;

        protected override void Awake()
        {
            if(singleton != null)
            {
                Destroy(this);
                return;
            }
            singleton = this;
            DontDestroyOnLoad(gameObject);
            base.Awake();
            Setup(IPAddress.Parse(iPAddress), udpPort);
        }

        public void Send()
        {
            this.Send("TestMessage");
        }

        public new void Send(string msg)
        {
            base.Send(msg);
        }

        protected override void OnGetMessage(string msg)
        {
            base.OnGetMessage(msg);
            Debug.Log(msg);
        }
    }
}