using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Ex1
{
    class Client
    {

        IPEndPoint ep;
        TcpClient client;
        NetworkStream stream;
        BinaryReader reader;
        BinaryWriter writer;
        public Client ()
        {
            this.ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            this.client = new TcpClient();
            this.client.Connect(ep);
            this.stream = client.GetStream();
            this.reader = new BinaryReader(stream);
            this.writer = new BinaryWriter(stream);
        }
        
        public void Close()
        {
            this.client.Close();
        }
        public void sendCommand(string s)
        {
            this.writer.Write(s);
            //the result
            
        }
       



    }
}

            
    


