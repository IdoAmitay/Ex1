using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
   public interface IController
    {
         void SetModel(IModel m);
         void SetView(IView v);
        void ExecuteCommand(string command, TcpClient client);
    }
}
