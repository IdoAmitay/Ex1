using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    class StartCommand : ICommand
    {
        private IModel model;
        public StartCommand(IModel model)
        {
            this.model = model;
        }
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
          return   this.model.Start(name, rows, cols, client);
        }
    }
}
