using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
   public class ListCommand:ICommand
    {
        private IModel model;
        public ListCommand(IModel m)
        {
            this.model = m;
        }

        public void ExecuteCommand(string[] args, TcpClient client = null)
        {
            this.model.List();
        }
    }
}
