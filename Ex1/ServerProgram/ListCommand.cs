using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
   public class ListCommand:ICommand
    {
        private IModel model;
        public ListCommand(IModel m)
        {
            this.model = m;
        }

        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
           return this.model.List(client);
        }
    }
}
