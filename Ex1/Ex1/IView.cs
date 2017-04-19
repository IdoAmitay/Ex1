using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
   public interface IView
    {
        void GetCommand(string s, TcpClient client);
        void ShowResult(string s, TcpClient client);
    }
}
