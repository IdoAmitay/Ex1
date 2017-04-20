using System;
using System.Collections.Generic;
using System.Configuration;
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
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public Client ()
        {
            string s = ConfigurationManager.AppSettings["server"].ToString();
            int p = int.Parse(ConfigurationManager.AppSettings["port"].ToString());

            this.ep = new IPEndPoint(IPAddress.Parse(s), p);
            this.client = new TcpClient();
            this.client.Connect(ep);
            Console.WriteLine("connected");
            this.stream = client.GetStream();
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
            this.writer.AutoFlush = true;
            // writer.Write("Generate maze 4 4");
            /*using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))*/
           // {
                /*  // Send data to server
                  Console.Write("Please enter a number: ");
                  int num = int.Parse(Console.ReadLine());
                  writer.Write(num);
                  // Get result from server
                  int result = reader.ReadInt32();
                  Console.WriteLine("Result = {0}", result);*/
                string myCommand = Console.ReadLine();
                writer.Write(myCommand);
          //  }
        }
        public bool IsConnected ()
        {
            if (this.client != null)
            {
                Socket clientSocket = this.client.Client;
                bool isSocketAvailable = clientSocket.Poll(1000, SelectMode.SelectRead);
                bool receivedDataIndicator;
                if (clientSocket.Available == 0)
                {
                    receivedDataIndicator = false;
                }
                else
                {
                    receivedDataIndicator = true;
                }
                //return !(socketPoll && !receivedDataIndicator);
                if (isSocketAvailable && receivedDataIndicator)
                {
                    return true;
                } 
                else
                {
                    return false;
                }
            }
            return false;
        }
        public void CommunicateWithServer()
        {
            string str;
            while (IsConnected())
            {
                str = this.reader.ReadLine();
            }
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

            
    


