using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : Searcher<T>
    {
        public override Solution<T> search(ISearchable<T> searchable)
        {
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
                                                         // HashSet<State<T>> closed = new HashSet<State<T>>();
            Dictionary<int, State<T>> closed = new Dictionary<int, State<T>>();

            while (OpenListSize > 0)
            {
            State<T> n = popOpenList(); // inherited from Searcher, removes the best state
                //closed.Add(n);
                closed.Add(n.GetHashCode(), n);


                if (n.Equals(searchable.getGoalState()))
                {
                    Solution<T> sol = new Solution<T>();

                    while (n.cost != 0)
                    {
                        sol.Add(n);
                        n = n.cameFrom;
                    }

                    sol.Add(n);
                    return sol;  
                }
                else
                {
                    
                    List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                    while (succerssors.Count > 0)
                    {
                        State<T> s = succerssors.First();

                        if (!openContaines(s) && !closed.ContainsKey(s.GetHashCode()))
                        {
                            s.cameFrom = n;
                            s.cost = n.cost + 1;
                            addToOpenList(s);
                        }
                        succerssors.Remove(s);
                    }
                  /*  State<T> s;
                    do
                    {
                        s = succerssors.First();
                        succerssors.Remove(s);
                    } while (closed.Contains(s));
                    s.cameFrom = n;
                    n = s;*/


                }
            }
            return null;
        }
    }
}
