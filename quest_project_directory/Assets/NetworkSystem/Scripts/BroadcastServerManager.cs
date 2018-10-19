using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetwrokSystem
{
    public class BroadcastServerManager : BroadcastSystem
    {
        [SerializeField] private ServerManager serverManager;

        public static BroadcastServerManager singleton;

        protected override void Awake()
        {
            singleton = this;
            base.Awake();
            if (serverManager == null)
                serverManager = GetComponent<ServerManager>();
        }

        public void StartCast()
        {
            BeginSend(serverManager.castPort, serverManager.tcpPort.ToString());
        }

        public void StopCast()
        {
            StopSend();
        }
    }
}