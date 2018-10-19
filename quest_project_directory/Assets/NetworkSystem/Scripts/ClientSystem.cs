using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetwrokSystem
{
    public class ClientSystem : MonoBehaviour
    {
        private UdpClient m_Client;
        private IPAddress m_IPAddress;
        private int m_Port;
        private byte[] m_Buffer;

        private AsyncCallback OnWriteCallback;

        private Queue<string> sendMessageQueue;
        private bool isSending;

        protected virtual void Awake()
        {
            m_Buffer = new byte[1024];

            OnWriteCallback = new AsyncCallback(OnWrite);

            sendMessageQueue = new Queue<string>();
            isSending = false;
        }

        protected void Setup(IPAddress address, int port)
        {
            Debug.Log("Setup : " + address.ToString() + ":" + port);

            m_Client = new UdpClient();
            SetEndPoint(address, port);
        }

        protected void SetEndPoint(IPAddress address, int port)
        {
            m_IPAddress = address;
            m_Port = port;
        }

        protected void DisConnect()
        {
            Debug.Log("DisConnect");

            m_Client.Close();
            m_Client = null;
        }

        protected void Send(string msg)
        {
            if (m_Client == null) return;
            sendMessageQueue.Enqueue(msg);
            if (isSending)
                return;
            SendQueue();
        }

        private void SendQueue()
        {
            isSending = true;
            try
            {
                Debug.Log("sendQueue");
                byte[] sendBytes = Encoding.UTF8.GetBytes(sendMessageQueue.Dequeue());
                m_Client.BeginSend(sendBytes, sendBytes.Length, new IPEndPoint(m_IPAddress, m_Port),OnWriteCallback, m_Client);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                isSending = false;
            }
        }

        protected virtual void OnGetMessage(string msg)
        {

        }

        private void OnWrite(IAsyncResult ar)
        {
            Debug.Log("OnWrite");
            m_Client.EndSend(ar);
            isSending = false;
            if (sendMessageQueue.Count > 0) SendQueue();
        }
    }
}