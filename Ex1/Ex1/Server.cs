using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Server
    {
        private int port;
        string s = ConfigurationManager.AppSettings["server"].ToString();
        private TcpListener listener;
        private IClientHandler ch;
        //private Task task;
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(s), port);
            //IPEndPoint(IPAddress.Parse("127.0.0.1"), port);


            listener = new TcpListener(ep);

            listener.Start();
            // this.task.Start();
            Task task = new Task(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        ch.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            task.Start();

        }
       
       
 
        public void Stop()
        {
            this.listener.Stop();
        }

    }
}
