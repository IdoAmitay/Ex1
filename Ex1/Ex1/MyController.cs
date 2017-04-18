using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex1
{
    public class MyController : IController
    {
        private IModel m;
        private IView v;
        private Dictionary<string, ICommand> commandList;
        public MyController()
        {
            commandList = new Dictionary<string, ICommand>();
            commandList.Add("generate", new GenerateCommand(this.m));
            commandList.Add("solve", new SolveCommand(this.m));
            commandList.Add("start", new StartCommand(this.m));
            commandList.Add("list", new ListCommand(this.m));
            commandList.Add("join", new JoinCommand(this.m));
            commandList.Add("play", new PlayCommand(this.m));
            commandList.Add("close", new CloseCommand(this.m));


            //addong the commands
        }
        public void SetModel(IModel m)
        {
            this.m = m;
           
        }

        public void SetView(IView v)
        {
            this.v = v;
        }
        void ExecuteCommand(string command, TcpClient client)
        {
            string[] arr = command.Split(' ');
            string commandKey = arr[0];
            if (!commandList.ContainsKey(commandKey))
            {
                //return not found
                this.v.ShowResult("Command not Found");
            }
            else
            {
                string[] args = arr.Skip(1).ToArray();
                ICommand com = commandList[commandKey];
                string result = com.ExecuteCommand(args, client);
                this.v.ShowResult(result);
            }
        }
    }
}
