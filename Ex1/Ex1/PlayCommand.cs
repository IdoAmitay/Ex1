using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
   public class PlayCommand:ICommand
    {
        private IModel model;
        private PlayCommand(IModel model)
        {
            this.model = model;
        }

        public void ExecuteCommand(string[] args, TcpClient client = null)
        {
            int move = int.Parse(args[0]);
            this.model.play(move, client);
        }
    }
}
