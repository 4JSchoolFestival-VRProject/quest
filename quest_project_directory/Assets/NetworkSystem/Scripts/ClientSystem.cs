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
        private TcpClient m_Client;
        private NetworkStream m_Stream;
        private byte[] m_Buffer;

        private AsyncCallback OnConnectCallback;
        private AsyncCallback OnReadCallback;
        private AsyncCallback OnWriteCallback;

        protected virtual void Awake()
        {
            m_Buffer = new byte[1024];

            OnConnectCallback = new AsyncCallback(OnConnect);
            OnReadCallback = new AsyncCallback(OnRead);
            OnWriteCallback = new AsyncCallback(OnWrite);
        }

        protected void BeginConnect(IPAddress address, int port)
        {
            Debug.Log("BeginConnect : " + address.ToString() + ":" + port);

            m_Client = new TcpClient();
            m_Client.BeginConnect(address, port, OnConnectCallback, m_Client);
        }

        protected void DisConnect()
        {
            Debug.Log("DisConnect");

            m_Stream.Close();
            m_Client.Close();
            m_Stream = null;
            m_Client = null;
        }

        protected void Send(string msg)
        {
            try
            {
                byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
                m_Stream.BeginWrite(sendBytes, 0, sendBytes.Length, OnWriteCallback, m_Stream);
            }
            catch(Exception ex) { Debug.Log(ex); }
        }

        protected virtual void OnGetMessage(string msg)
        {

        }

        private void OnConnect(IAsyncResult ar)
        {
            Debug.Log("OnConnect");
            try
            {
                TcpClient server = ar.AsyncState as TcpClient;
                Debug.Log("Connect : " + server.Client.RemoteEndPoint);
                m_Stream = server.GetStream();
                m_Stream.BeginRead(m_Buffer, 0, m_Buffer.Length, OnReadCallback, m_Stream);
            }
            catch (Exception ex) { Debug.Log(ex); }
        }

        private void OnRead(IAsyncResult ar)
        {
            Debug.Log("OnRead");

            int byteRead = m_Stream.EndRead(ar);
            if (byteRead > 0)
            {
                string msg = Encoding.UTF8.GetString(m_Buffer, 0, m_Buffer.Length);
                OnGetMessage(msg);
            }
            else
                DisConnect();
        }

        private void OnWrite(IAsyncResult ar)
        {
            Debug.Log("OnWrite");
            m_Stream.EndWrite(ar);
            m_Stream.BeginRead(m_Buffer, 0, m_Buffer.Length, OnRead, m_Stream);
        }
    }
}