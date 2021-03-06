﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
   public interface IController
    {
         void SetModel(IModel m);
         void SetView(IView v);
        bool ExecuteCommand(string command, TcpClient client);
        void DataHasChanged(string data, TcpClient client);
    }
}
