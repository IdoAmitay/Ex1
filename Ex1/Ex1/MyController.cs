using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex1
{
    public class MyController<T> : IController<T>
    {
        private IModel<T> m;
        private IView<T> v;
        private Dictionary<string, ICommand> commandList;
        public MyController()
        {
            commandList = new Dictionary<string, ICommand>();
            //addong the commands
        }
        public void SetModel(IModel<T> m)
        {
            this.m = m;
           
        }

        public void SetView(IView<T> v)
        {
            this.v = v;
        }
        void ExecuteCommand(string command, TcpClient client)
        {

        }
    }
}
