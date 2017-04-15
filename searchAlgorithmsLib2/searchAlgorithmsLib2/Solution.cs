using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchAlgorithmsLib2
{
    public class Solution<T>
    {
        List<State<T>> statesList { get; set; }
        public void Add(State<T> state)
        {
            this.statesList.Add(state);
        }
    }
}
