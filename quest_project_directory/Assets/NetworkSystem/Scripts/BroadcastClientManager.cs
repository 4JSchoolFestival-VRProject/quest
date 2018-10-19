using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace NetwrokSystem
{
    public class BroadcastClientManager : BroadcastSystem
    {
        [SerializeField] private ClientManager clientManager;

        public static BroadcastClientManager singleton;

        protected override void Awake()
        {
            singleton = this;
            base.Awake();
            if(clientManager == null)
               clientManager = GetComponent<ClientManager>();
        }

        private void Start()
        {
            StartListen();
        }

        public void StartListen()
        {
            BeginListen(clientManager.castPort);
        }

        protected override void OnGetBroadcast(IPEndPoint endPoint, string msg)
        {
            Debug.Log("OnGetBroadcast");
            base.OnGetBroadcast(endPoint, msg);

            Debug.Log(endPoint.Address + " : " + endPoint.Port + " : " + msg);
            clientManager.Connect(endPoint.Address, int.Parse(msg));
        }
    }
}