using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NetwrokSystem
{
    public class ClientManager : ClientSystem
    {
        [SerializeField] public int castPort = 50001;

        public void Connect(IPAddress address, int port)
        {
            BeginConnect(address, port);
        }

        public void Send()
        {
            base.Send("TestMessage");
        }

        protected override void OnGetMessage(string msg)
        {
            base.OnGetMessage(msg);
            Debug.Log(msg);
        }
    }
}