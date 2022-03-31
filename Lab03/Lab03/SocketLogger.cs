using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Lab03
{
    class SocketLogger : ILogger
    {
        private ClientSocket clientSocket;

        public SocketLogger(string host, int port)
        {
            clientSocket = new ClientSocket(host, port);
        }

        ~SocketLogger()
        {
            clientSocket.Dispose(false);
        }

        public void Log(params string[] messages)
        {
            DateTime time = DateTime.Now;
            byte[] request = Encoding.ASCII.GetBytes(String.Format(time.ToString("yyyy-MM-ddTHH:mm:sszzz") + ": " + String.Join(" ", messages)));
            clientSocket.Send(request);
        }

        public void Dispose()
        {
            this.clientSocket.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
