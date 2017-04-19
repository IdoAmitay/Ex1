using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace Ex1
{
    public abstract class Game<T> : IProblem<T>
    {
        protected SearchAlgorithmsLib.ISearchable<T> searchable { get; set; }
        protected List<TcpClient> clients { get; set; }
        protected string nameOfGame { get; set; }
        //MazeGeneratorLib.IMazeGenerator generator;
       // private string solution;
       // private SearchAlgorithmsLib.ISearcher<T> solver;
        
        public void AddPlayer (TcpClient client)
        {
            this.clients.Add(client);
            
        }
        public void SetName(string name)
        {
            this.nameOfGame = name;
        }

        public abstract void Solve(ISearchable<T> s);
        
        /* public void SetGenerator (MazeGeneratorLib.IMazeGenerator generator)
{
    this.generator = generator;
}*/

    }
}
