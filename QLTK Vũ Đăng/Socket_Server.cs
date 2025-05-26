using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QLTK_Vũ_Đăng
{
    internal class Socket_Server
    {
        public static void SetupServer()
        {
            new Thread(() =>
            {
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 772));
                _serverSocket.Listen(10);
                _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
            })
            { IsBackground = true }.Start();
        }
        private static List<vSocket> __ClientSockets { get; set; } = new List<vSocket>();

        private static byte[] _buffer = new byte[2048];
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        public class vMessage
        {
            public int cmd;
            public object data;
        }


        static void onMessage(string data, Socket socket)
        {
            try
            {
                var msg = JsonConvert.DeserializeObject<vMessage>(data);
                switch (msg.cmd)
                {
                    case 0: // connect
                        for (int j = 0; j < __ClientSockets.Count; j++)
                        {
                            if (socket.RemoteEndPoint.ToString().Equals(__ClientSockets[j]._Socket.RemoteEndPoint.ToString()))
                            {

                                __ClientSockets[j]._Name = (string)msg.data;
                                break;
                            }
                        }
                        break;
                    case 1912:
                        FormControlGame.idTele = Convert.ToInt32(msg.data);
                        break;
                    case 1301:
                        Socket_Server.sendData(new vMessage()
                        {
                            cmd = 17,
                            data = 1912
                        });
                        break;
                    case 9999:
                        Socket_Server.sendData(new Socket_Server.vMessage()
                        {
                            cmd = 7,
                            data = -1
                        });
                        break;
                    case 2005:
                        Socket_Server.sendData(new Socket_Server.vMessage()
                        {
                            cmd = 17,
                            data = -1
                        });
                        break;
                }
            }
            catch (Exception e)
            {
            }
        }


        private static void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            if (socket.Connected)
            {
                int num = 0;
                try
                {
                    num = socket.EndReceive(ar);
                }
                catch { }

                if (num != 0)
                {
                    try
                    {
                        byte[] array = new byte[num];
                        Array.Copy(_buffer, array, num);
                        string @string = Encoding.UTF8.GetString(array);
                        onMessage(@string, socket);
                        socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                    }
                    catch (Exception e)
                    {
                        goto close;
                    }
                    return;
                }
            }
        close:
            for (int z = 0; z < __ClientSockets.Count; z++)
            {
                try
                {
                    var s = __ClientSockets[z];
                    if (s._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                    {
                        try
                        {
                            s._Socket.Close();
                        }
                        catch { }
                        __ClientSockets.RemoveAt(z);
                    }
                }
                catch { }
            }
        }
        public static void sendDataToAcc(object acc, object data)
        {
            new Thread(() =>
            {
                var s = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                for (int j = 0; j < __ClientSockets.Count; j++)
                {
                    if (__ClientSockets[j]._Socket.Connected && __ClientSockets[j]._Name == (string)acc)
                    {
                        Sendata(__ClientSockets[j]._Socket, s);
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }

        public static void sendData(object data)
        {
            new Thread(() =>
            {
                var s = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                for (int j = 0; j < __ClientSockets.Count; j++)
                {
                    if (__ClientSockets[j]._Socket.Connected)
                    {
                        Sendata(__ClientSockets[j]._Socket, s);
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }
        private static void Sendata(Socket socket, byte[] b)
        {
            socket.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private static void AppceptCallback(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            __ClientSockets.Add(new vSocket(socket));
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private static void SendCallback(IAsyncResult AR)
        {
            ((Socket)AR.AsyncState).EndSend(AR);
        }

        public class vSocket
        {
            public Socket _Socket { get; set; }

            public string _Name { get; set; }

            public vSocket(Socket socket)
            {
                _Socket = socket;
            }
        }
    }
}
