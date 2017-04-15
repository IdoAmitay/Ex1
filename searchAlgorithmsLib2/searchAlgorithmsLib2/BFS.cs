using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchAlgorithmsLib2
{
    public class BFS<T> : Searcher<T>
    {
        public override Solution<T> search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                {
                    Solution<T> sol = new Solution<T>();

                    while (n.cost != 0)
                    {
                        sol.Add(n);
                        n = n.cameFrom;
                    }

                    sol.Add(n);
                    return sol;  // private method, back traces through the parents
                                 // calling the delegated method, returns a list of states with n as a parent
                }
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openContaines(s))
                    {
                        // s.setCameFrom(n); // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else
                    {
                        if (s.cost > n.cost + 1 && openContaines(s))
                        {
                            s.cameFrom = n;
                            s.cost = n.cost + 1;
                        }
                    }
                }
            }
            return null;
        }
    }
}
