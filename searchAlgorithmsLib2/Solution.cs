using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        List<State<T>> statesList { get; set;} 
        public void Add (State<T> state)
        {
            this.statesList.Add(state);
        }
    }
}
