using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;

namespace Ex1
{
    public class MazeAdapter : SearchAlgorithmsLib.ISearchable<MazeLib.Position>
    {
        private Maze maze;
        public MazeAdapter(Maze maze)
        {
            this.maze = maze;
        }
        public  List<State<MazeLib.Position>> getAllPossibleStates(State<MazeLib.Position> s)
        {
            List<State<MazeLib.Position>> statesList = new List<State<Position>>();
            //State<MazeLib.Position>.statePool.getState(s);
            if(maze.Rows - 1 > s.state.Row && maze[s.state.Row +1,s.state.Col] == CellType.Free )
            {
                Position p = new Position(s.state.Row + 1, s.state.Col);
                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)));

                /*if (!s.cameFrom.Equals(State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p))))
                {

                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cost = s.cost + 1;
                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cameFrom = s;
                }*/



            }
            if (s.state.Row > 0 && maze[s.state.Row - 1, s.state.Col] == CellType.Free)
            {
                Position p = new Position(s.state.Row - 1, s.state.Col);

                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState(p));
                
                /*if (!s.cameFrom.Equals(State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p))))
                {
                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cost = s.cost + 1;
                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cameFrom = s;
                }*/
            }
            if (maze.Cols - 1 > s.state.Col && maze[s.state.Row, s.state.Col + 1] == CellType.Free )
            {
                Position p = new Position(s.state.Row, s.state.Col + 1);
                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState(p));
              /*  if (!s.cameFrom.Equals(State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p))))
                {

                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cost = s.cost + 1;
                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cameFrom = s;
                }*/
            }
            if (s.state.Col > 0 && maze[s.state.Row, s.state.Col - 1] == CellType.Free )
            {
                Position p = new Position(s.state.Row, s.state.Col - 1);
                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState(p));
                /*if (!s.cameFrom.Equals(State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p))))
                {

                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cost = s.cost + 1;
                    State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)).cameFrom = s;
                }*/
            }


            return statesList;



        }

        

        public State<MazeLib.Position> getGoalState()
        {
            return new State<MazeLib.Position>(maze.GoalPos);
        }

        public State<MazeLib.Position> getInitialState()
        {
            return new State<Position>(maze.InitialPos);
        }
        public void SetMazeName(string name)
        {
            this.maze.Name = name;
        }
        public string getMazeName()
        {
            return this.maze.Name;
        }
        public override string ToString()
        {
            return this.maze.ToJSON();
        }
        
    }
}
