using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public abstract class SearcherNonPriority<T> : ISearcher<T>
    {
        private Stack<State<T>> openList;
        private int evaluatedNodes;

        public SearcherNonPriority()
        {
            openList = new Stack<State<T>>();
            evaluatedNodes = 0;
        }

        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Pop(); //////////// ask someone what needs to be instead of poll!!
        }

        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public abstract Solution<T> search(ISearchable<T> searchable);

        public void addToOpenList(State<T> state)
        {
            openList.Push(state);
        }

        public bool openContaines(State<T> s)
        {
            return openList.Contains(s);
        }
    }
}
