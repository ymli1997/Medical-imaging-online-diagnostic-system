using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
    internal delegate void SocketAcceptedHandler(object sender, SocketAcceptedEventArgs e);

    internal class SocketAcceptedEventArgs : EventArgs
    {
        public Socket Accepted
        {
            get;
            private set;
        }

        public IPAddress Address
        {
            get;
            private set;
        }

        public IPEndPoint EndPoint
        {
            get;
            private set;
        }

        public SocketAcceptedEventArgs(Socket sck)
        {
            Accepted = sck;
            Address = ((IPEndPoint)sck.RemoteEndPoint).Address;
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
        }
    }

    internal class Listener
    {
        #region Variables
        private Socket _socket = null;
        private bool _running = false;
        private int _port = -1;
        #endregion

        #region Properties
        public Socket BaseSocket
        {
            get { return _socket; }
        }

        public bool Running
        {
            get { return _running; }
        }

        public int Port
        {
            get { return _port; }
        }
        #endregion

        public event SocketAcceptedHandler Accepted;

        public Listener()
        {

        }

        public void Start(int port)
        {
            if (_running)
                return;

            _port = port;
            _running = true;
            _socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            string address = "2001:da8:270:2021::f"; //服务器IP地址，端口号在Main.cs源代码btnStartServer_Click里设置
            IPAddress ipAddress = IPAddress.Parse(address);
            _socket.Bind(new IPEndPoint(ipAddress, port));
            _socket.Listen(100);
            _socket.BeginAccept(acceptCallback, null);
        }

        public void Stop()
        {
            if (!_running)
                return;

            _running = false;
            _socket.Close();
        }

        private void acceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket sck = _socket.EndAccept(ar);

                if (Accepted != null)
                {
                    Accepted(this, new SocketAcceptedEventArgs(sck));
                }
            }
            catch
            {
            }

            if (_running)
                _socket.BeginAccept(acceptCallback, null);
        }
    }
