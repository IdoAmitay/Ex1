using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    public interface IModel
    {
        //void Solve(SearchAlgorithmsLib.ISearchable<T> s);

        //void Solve(IProblem<T> p);
        bool Generate(string name, int rows, int cols, TcpClient client);
        bool Solve(string name, int algorithm, TcpClient client);
        bool Start(string name, int rows, int cols,TcpClient client);
        /*List<string>*/
        bool List(TcpClient client);
        bool Join(string name, TcpClient client);
        bool play(int move,TcpClient client);
        bool close(string name, TcpClient client);

    }
}
