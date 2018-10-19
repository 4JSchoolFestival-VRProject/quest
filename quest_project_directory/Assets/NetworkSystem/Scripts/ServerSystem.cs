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
    public class ServerSystem : MonoBehaviour
    {
        public bool isConnect { get { return m_Client != null; } }

        private TcpListener m_Listener;
        private TcpClient m_Client;
        private NetworkStream m_Stream;
        private byte[] m_Buffer;

        private AsyncCallback OnAcceptCallback;
        private AsyncCallback OnReadCallback;
        private AsyncCallback OnWriteCallback;

        protected virtual void Awake()
        {
            m_Buffer = new byte[1024];
        }

        protected void BeginAccept(IPAddress address, int port)
        {
            Debug.Log("BeginAccept : " + address.ToString() + ":" + port);
            try
            {
                m_Listener = new TcpListener(address, port);
                m_Listener.Start();
                m_Listener.BeginAcceptTcpClient(OnAcceptCallback, m_Listener);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        protected void DisConnect()
        {
            Debug.Log("DisConnect");

            m_Stream.Close();
            m_Listener.Stop();
            m_Stream = null;
            m_Listener = null;
        }

        protected virtual void OnConnectClient(TcpClient client)
        {

        }

        protected virtual void OnGetMessage(string msg)
        {

        }

        private void OnAcceptClient(IAsyncResult ar)
        {
            Debug.Log("OnAcceptClient");
            try
            {
                TcpListener listener = ar.AsyncState as TcpListener;
                m_Client = listener.EndAcceptTcpClient(ar);
                Debug.Log("Connect : " + m_Client.Client.RemoteEndPoint);
                m_Stream = m_Client.GetStream();
                m_Stream.BeginRead(m_Buffer, 0, m_Buffer.Length, OnReadCallback, m_Stream);
                OnConnectClient(m_Client);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
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