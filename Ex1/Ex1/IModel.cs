using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public interface IModel
    {
        //void Solve(SearchAlgorithmsLib.ISearchable<T> s);

        //void Solve(IProblem<T> p);
        string Generate(string name, int rows, int cols);
        string Solve(string name, int algorithm);
        void Start(string name, int rows, int cols,TcpClient client);
        List<string> List();
        void Join(string name, TcpClient client);
        void play(int move,TcpClient client);
        void close(string name);

    }
}
