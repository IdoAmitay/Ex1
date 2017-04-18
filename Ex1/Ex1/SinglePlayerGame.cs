using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace Ex1
{
    class SinglePlayerGame<T> : Game<T>
    {
        private SearchAlgorithmsLib.ISearcher<T> searcher;
        private Solution<T> solution;
        public override void Solve(ISearchable<T> s)
        {
            this.solution = this.searcher.search(s);
            
        }

        
    }
}
