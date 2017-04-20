using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int p = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
            IController controller = new MyController();
            IModel model = new MyModel<MazeLib.Position>(controller);
            
            ClientHandler ch = new ClientHandler(controller);
            controller.SetModel(model);
            controller.SetView(ch);
            Server server = new Server(p, ch);
            server.Start();
            Client client = new Client();
            /*string str = Console.ReadLine();
            client.sendCommand(str);*/
           // server.Stop();
        }
    }
}
