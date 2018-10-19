using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

namespace NetwrokSystem
{
    public class ServerManager : ServerSystem
    {
        [SerializeField] public int tcpPort = 50000;
        [SerializeField] public int castPort = 50001;

        public void StartAccept()
        {
            BeginAccept(IPAddress.Any, tcpPort);
        }

        protected override void OnConnectClient(TcpClient client)
        {
            base.OnConnectClient(client);
            BroadcastServerManager.singleton.StopCast();
        }

        protected override void OnGetMessage(string msg)
        {
            base.OnGetMessage(msg);
            Debug.Log(msg);
        }
    }
}