using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

public delegate void MessageHandler(object msg);

public class NetManager : Singleton<NetManager>
{
    public enum ConnectState
    {
        TryConnecting,
        NonConnect,
        Connected,
        ConnectingOutTime,
    }

    private TcpClient mClient;
    private NetworkStream mStream;

    private bool mRunningShread;
    private Thread mReciveThread;
    private Thread mSendThread;

    private const int BUFFER_SIZE = 1024;
    private List<string> mProtocolBuffer;
    private List<string> mSendBuffer; 

    public ConnectState connectState;

    public void TryConnect(string server, int port)
    {
        try
        {
            mClient = new TcpClient();
            mClient.BeginConnect(server, port, ConnectCallback, null);
            mStream = mClient.GetStream();
            connectState = ConnectState.TryConnecting;
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void Close()
    {
        connectState = ConnectState.NonConnect;
        mRunningShread = false;
        mClient.Close();
        mStream.Close();
    }

    public void StartRun()
    {
        mRunningShread = true;
        mReciveThread = new Thread(ReceiveFunc);
        mReciveThread.Start();

        mSendThread = new Thread(SendFunc);
        mSendThread.Start();
    }

    #region self action
    private void ReceiveFunc()
    {
        mProtocolBuffer = new List<string>(BUFFER_SIZE);
        byte[] bytes = new byte[BUFFER_SIZE];

        while (mRunningShread)
        {
            int len = mStream.Read(bytes, 0, bytes.Length);
            if (len > 6)
            {
                
            }
        }
    }

    private void SendFunc()
    {
        while (mRunningShread)
        {

        }
    }

    private void ConnectCallback(object obj)
    {
        connectState = mClient.Connected ? ConnectState.Connected : ConnectState.ConnectingOutTime;
    }
    #endregion
    public void SendMessage()
    {
        
    }

    public void RegisterMessageHandler(string singture, MessageHandler handler)
    {
                
    }
}