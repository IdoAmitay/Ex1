using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    class JoinCommand : ICommand
    {
        private IModel model;
        public JoinCommand(IModel model)
        {
            this.model = model;
        }
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
           return  this.model.Join(name,client);
        }
    }
}
