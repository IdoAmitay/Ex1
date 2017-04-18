using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class CloseCommand : ICommand
    {
        IModel model;
        public CloseCommand(IModel model)
        {
            this.model = model;
        }
        public void ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            this.model.close(name);
        }
    }
}
