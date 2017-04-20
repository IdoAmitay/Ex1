using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProgram
{
    class ClientHandler : IClientHandler,IView
    {
        // private IView v;
        private NetworkStream stream;
       private  StreamReader reader;
        private StreamWriter writer;
        private bool continueConnection;
        private IController c;
        /*public ClientHandler (IView v)
        {
            this.v = v;
        }*/
        public ClientHandler(IController c)
        {
            this.c = c;
            this.continueConnection = true;
        }
       

        public void HandleClient(TcpClient client)
        {

           // this.stream = client.GetStream();
          //  this.reader = new StreamReader(stream);
            //this.writer = new StreamWriter(stream);

            new Task(() =>
            {

                NetworkStream stream = client.GetStream();
              StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
           
                   
                {
                    while (continueConnection)
                    {
                        try
                        {
                            string commandLine = reader.ReadLine();

                            Console.WriteLine("Got command: {0}", commandLine);
                            /*string result =*/
                            // this.v.GetCommand(commandLine, client);
                            //writer.Write(result);
                            continueConnection = this.c.ExecuteCommand(commandLine, client);
                            Console.WriteLine(continueConnection);
                            /*GetCommand(commandLine, client)*/
                        }
                        catch(SocketException)
                        {
                            break;
                        }



                    }

                }
                

                    
                
                client.Close();
            }).Start();
        }

        public bool GetCommand(string s, TcpClient client)
        {
            return this.c.ExecuteCommand(s, client);

          
        }

        public void ShowResult(string s, TcpClient client)
        {
            //////////////////////////////////////////
            //writer.Write(s);
            Console.WriteLine(s);
        }
    }
}
