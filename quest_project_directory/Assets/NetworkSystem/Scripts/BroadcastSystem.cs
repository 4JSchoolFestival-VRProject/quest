using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NetwrokSystem
{
    public class BroadcastSystem : MonoBehaviour
    {
        private UdpClient m_Client;

        private IEnumerator SendBroadcastTask;
        private AsyncCallback OnReceiveCallback;

        protected virtual void Awake()
        {
            OnReceiveCallback = new AsyncCallback(OnReceive);
        }

        protected void BeginSend(int port, string msg)
        {
            Debug.Log("BeginSend : " + port + ":" + msg);
            SendBroadcastTask = SendBroadcast(port, msg);
            StartCoroutine(SendBroadcastTask);
        }

        private IEnumerator SendBroadcast(int port, string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            m_Client = new UdpClient(port);

            while (true)
            {
                try
                {
                    Debug.Log("Send : " + port + ":" + msg);
                    m_Client.EnableBroadcast = true;
                    m_Client.Connect(new IPEndPoint(IPAddress.Broadcast, port));
                    m_Client.Send(buffer, buffer.Length);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex);
                    m_Client.Close();
                    m_Client = null;
                    yield break;
                }
                yield return new WaitForSeconds(5.0f);
            }
        }


        protected void StopSend()
        {
            StopCoroutine(SendBroadcastTask);
            m_Client.Close();
            m_Client = null;
        }

        protected void BeginListen(int port)
        {
            Debug.Log("BeginListen");

            try
            {
                UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                client.BeginReceive(OnReceiveCallback, client);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        protected virtual void OnGetBroadcast(IPEndPoint endPoint, string msg) { }

        private void OnReceive(IAsyncResult ar)
        {
            Debug.Log("OnReceiveBroadcast");

            try
            {
                UdpClient client = ar.AsyncState as UdpClient;
                IPEndPoint remoteIP = null;
                byte[] buffer = client.EndReceive(ar, ref remoteIP);
                string msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                Debug.Log(remoteIP.Address + " : " + msg);
                OnGetBroadcast(remoteIP, msg);
            }
            catch (Exception ex) { Debug.Log(ex); }
        }
    }
}