using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class MyView : IView
    {
        private IController c;
        public MyView(IController c)
        {
            this.c = c;
        }
        public void GetCommand(string s, TcpClient client)
        {
            this.c.ExecuteCommand(s, client);
        }

        public void ShowResult(string s, TcpClient client)
        {
            //////////////////////////////////////////
        }
    }
}
