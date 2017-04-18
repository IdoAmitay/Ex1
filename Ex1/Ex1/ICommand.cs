using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
   public interface ICommand
    {
        string ExecuteCommand(string [] args, TcpClient client = null);
    }
}
