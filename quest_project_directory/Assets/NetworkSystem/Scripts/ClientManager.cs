using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace NetwrokSystem
{
    public class ClientManager : ClientSystem
    {
        [SerializeField] public int castPort = 50001;

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
        }

        protected override void Update()
        {
            base.Update();
            if (SceneManager.GetActiveScene().name == "Connection" && isConnecting)
            {
                Player.singleton.UpdateStatus(1, 40, true);
                Player.singleton.UpdateStatus(1, 40, false);
                SceneManager.LoadSceneAsync("Encount");
            }
        }

        public void Connect(IPAddress address, int port)
        {
            base.BeginConnect(address, port);
        }

        public void Send()
        {
            this.Send("TestMessage");
        }

        public new void Send(string msg)
        {
            base.Send(msg);
        }

        protected override void OnConnectedServer()
        {
            base.OnConnectedServer();
        }

        protected override void OnGetMessage(string msg)
        {
            base.OnGetMessage(msg);
            Debug.Log(msg);
        }
    }
}