using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class SolveCommand: ICommand
    {
        private IModel model;
        public SolveCommand(IModel model)
        {
            this.model = model;
        }
        public void ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
            this.model.Solve(name, algorithm);
        }
    }
}
