using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Comparer
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            CompareSolvers();
        }
        public static void CompareSolvers()
        {
            MazeGeneratorLib.DFSMazeGenerator generator = new MazeGeneratorLib.DFSMazeGenerator();
            MazeLib.Maze maze = generator.Generate(15, 15);
            Console.WriteLine(maze.ToString());
            MazeAdapter adapter = new MazeAdapter(maze);
            SearchAlgorithmsLib.Solution<MazeLib.Position> solBFS = new SearchAlgorithmsLib.Solution<MazeLib.Position>();
            SearchAlgorithmsLib.BFS<MazeLib.Position> bfs = new SearchAlgorithmsLib.BFS<MazeLib.Position>();
            solBFS = bfs.search(adapter);
            SearchAlgorithmsLib.DFS<MazeLib.Position> dfs = new SearchAlgorithmsLib.DFS<MazeLib.Position>();
            SearchAlgorithmsLib.Solution<MazeLib.Position> solDFS = new SearchAlgorithmsLib.Solution<MazeLib.Position>();
            solDFS = dfs.search(adapter);
            Console.WriteLine("in BFS: {0}, in DFS: {1}", bfs.getNumberOfNodesEvaluated(), dfs.getNumberOfNodesEvaluated());
            Console.WriteLine("Start: {0}, end: {1}", maze.InitialPos,maze.GoalPos);
           Console.WriteLine("BFS solution: ");
            solBFS.printSolution();
            Console.WriteLine("DFS solution: ");
            solDFS.printSolution();



        }
    }
}
