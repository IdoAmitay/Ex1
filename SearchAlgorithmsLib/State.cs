using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State<T>
    {
        public T state; // the state represented by a string
        public double cost { get; set; } // cost to reach this state (set by a setter)
        public State <T>cameFrom { get; set; } // the state we came from to this state (setter)
       

        public State(T state) // CTOR
        {
            this.state = state;
        }
        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return state.Equals(s.state);
        }
        
        public static class statePool<T>
        {
            static Dictionary<T, State<T>> states = new Dictionary<T, State<T>>();
            //static HashSet<State<T>> states = new HashSet<State<T>>();
          /*  public static void addState (State<T> s)
            {
                if(!states.Contains(s))
                {
                    states.Add(s);
                }
            }*/
            public static State<T> getState (T val)
            {
                if (!states.ContainsKey(val))
                {
                    
                    states.Add(val, new State<T>(val));
                }
                
                
                    return states[val];
                
            }
           
        }
        public override int GetHashCode()
        {
            return string.Intern(this.state.ToString()).GetHashCode();
           
        }

    }
}
