using System;
using System.Collections.Generic;
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
            IController controller = new MyController();
            IModel model = new MyModel<MazeLib.Position>(controller);
            
            ClientHandler ch = new ClientHandler(controller);
            controller.SetModel(model);
            controller.SetView(ch);
            Client client = new Client();
            Server server = new Server(8000, ch);
            server.Start();
            client.sendCommand("Generate");
        }
    }
}
