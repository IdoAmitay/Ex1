using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchAlgorithmsLib2
{
    public class State<T>
    {
        public T state; // the state represented by a string
        public double cost { get; set; } // cost to reach this state (set by a setter)
        public State<T> cameFrom { get; set; } // the state we came from to this state (setter)


        public State(T state) // CTOR
        {
            this.state = state;
        }
        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return state.Equals(s.state);
        }

        public T getState()
        {
            return this.state;
        }
        public int checkmyass()
        {
            return 1;
        }
    }
}
