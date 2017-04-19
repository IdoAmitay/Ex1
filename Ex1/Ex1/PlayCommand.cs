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
        public PlayCommand(IModel model)
        {
            this.model = model;
        }

        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            int move = int.Parse(args[0]);
            return this.model.play(move, client);
        }

        
    }
}
