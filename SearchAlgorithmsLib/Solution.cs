using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {

       // private List<State<T>> statesList { get; set; }
       private List<State<T>> statesList { get; set; }

        public Solution ()
        {
            statesList = new List<State<T>>();
        }
        public void Add (State<T> state)
        {
            this.statesList.Add(state);
        }
        public void printSolution()
        {
            while (statesList.Count > 0)
            {
                Console.WriteLine(statesList.First().state.ToString());
                statesList.RemoveAt(0);
                
            }
        }
        public List<State<T>> getStateList ()
        {
            return this.statesList;
        }
      
    }
}
