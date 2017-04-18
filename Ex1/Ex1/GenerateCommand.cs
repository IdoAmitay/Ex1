﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
   public class GenerateCommand : ICommand
    {
         private IModel model;
       // private MyModel<T> model;
        public GenerateCommand(IModel model)
        {
            this.model = model;
        }
        public string ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            /*SearchAlgorithmsLib.ISearchable<T> searchable =*/
           return this.model.Generate(name, rows, cols);

        }
    }
}