using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace Ex1
{
    public class MyModel<T> : IModel
    {
        private IController c;
        private ISearcher<T> searcher;
        private MazeGeneratorLib.IMazeGenerator generator;
        private Dictionary<ISearchable<T>, string> singleGameMaze;
        private Dictionary<ISearchable<T>, List<TcpClient>> multiPlayerGame;
        private Dictionary<ISearchable<T>, string> gamesNames;
       // private Dictionary<MazeAdapter, string> singleGameMaze;
       // private Dictionary<MazeAdapter, List<TcpClient>> multiPlayerGame;
        //private Dictionary<ISearchable<T>, string> gamesNames;

        
       /* public void Solve(ISearchable<T> s)
        {
           Solution<T> sol = this.searcher.search(s);
            //converting the solution to string
            string solution = "a";
            this.singleGameMaze.Add(s, solution);
        }*/
        public MyModel(IController c)
        {
            this.c = c;
            this.singleGameMaze = new Dictionary<ISearchable<T>, string>();
            this.multiPlayerGame = new Dictionary<ISearchable<T>, List<TcpClient>>();
            this.gamesNames = new Dictionary<ISearchable<T>, string>();
        }
        public void setSeasrcher(ISearcher<T> searcher)
        {
            this.searcher = searcher;
        }
        public bool Join(string nameOfGame, TcpClient client)
        {
            List<TcpClient> clients = null ;
            ISearchable<T> searchale = null;
             foreach (KeyValuePair<ISearchable<T>,string> key in gamesNames )
             {
                 if (key.Value.Equals(nameOfGame))
                 {
                     this.multiPlayerGame[key.Key].Add(client);
                    clients = this.multiPlayerGame[key.Key];
                    searchale = key.Key;
                     break;
                 }
             }
            /*foreach (KeyValuePair<MazeAdapter, List<TcpClient>> key in multiPlayerGame)
            {
                if (key.Key.getMazeName().Equals(nameOfGame))
                {
                    this.multiPlayerGame[key.Key].Add(client);
                    break;
                }
            }*/
            if (clients.Count() > 1)
            {
                foreach (TcpClient c in clients)
                {
                    this.c.DataHasChanged(searchale.ToString(), c);
                }
            }
            return true;
        }
       
        public void SetGenerator(MazeGeneratorLib.IMazeGenerator generator)
        {
            this.generator = generator;
        }
        public bool Generate(string name,int rows, int cols, TcpClient client)
        {
            //SetGenerator(new MazeGeneratorLib.DFSMazeGenerator());
            /* MazeLib.Maze maze = this.generator.Generate(rows, cols);
             maze.Name = name;
             ISearchable<T> adapter =(ISearchable<T>) new MazeAdapter(maze);*/
            ISearchable<T> searchable = CreateMaze(name, rows, cols);


            //this.gamesNames.Add(adapter, name);
            if (singleGameMaze.ContainsKey(searchable))
            {
                var item = gamesNames.First(kvp => kvp.Value == name);
                gamesNames.Remove(item.Key);

                item = singleGameMaze.First(kvp => kvp.Value == name);
                singleGameMaze.Remove(item.Key);


            }
            
            this.singleGameMaze.Add(searchable, null);
            this.gamesNames.Add(searchable, name);
            // return searchable.ToString();
            this.c.DataHasChanged(searchable.ToString(), client);
            return false;
        }
        public ISearchable<T> CreateMaze(string name, int rows, int cols)
        {
            MazeLib.Maze maze = this.generator.Generate(rows, cols);
            maze.Name = name;
            return (ISearchable<T>)new MazeAdapter(maze);

        }
        
        public bool Start(string name,int rows,int cols, TcpClient client)
        {
            /*MazeLib.Maze maze = this.generator.Generate(rows, cols);
            maze.Name = name;
            ISearchable<T> adapter =(ISearchable<T>) new MazeAdapter(maze);*/
            ISearchable<T> searchable = CreateMaze(name, rows, cols);
           // adapter.SetMazeName(name);
            List<TcpClient> clients = new List<TcpClient>();
            clients.Add(client);
            if (this.multiPlayerGame.ContainsKey(searchable))
            {
                //this.singleGameMaze.Remove(adapter);
                // Console.WriteLine("");
                this.c.DataHasChanged("Name exist", client);
                return false;

            }
            else
            {
                this.multiPlayerGame.Add(searchable, clients);
                this.c.DataHasChanged(searchable.ToString(), client);
                return true;

            }

        }
        public bool /*List<string>*/ List(TcpClient client)
        {
            //List<string> games = new List<string>();
            string gamesString = "";
            foreach (KeyValuePair<ISearchable<T>, List<TcpClient>> key in multiPlayerGame)
            {
                //games.Add(gamesNames[key.Key]);
                gamesString += gamesNames[key.Key] + "/n";
            }
            //return games;
            this.c.DataHasChanged(gamesString, client);
            return false;
        }
        public ISearchable<T> getMazeByName(string name)
        {
            foreach (KeyValuePair<ISearchable<T>,string> key in gamesNames)
            {
                if(key.Value.Equals(name))
                {
                    return key.Key;
                }
            }
            return null;
        }

      
        public bool play(int move, TcpClient client)
        {
            /////////////////////////////////////////
            return true;
        }

        public bool Solve(string name, int algorithm, TcpClient client)
        {
            if (!gamesNames.ContainsValue(name))
            {
                // return "name doesn't exist";
                this.c.DataHasChanged("name doesn't exist", client);
            
            }
            else
            {
                switch (algorithm)
                {
                    case 0:
                        {
                            setSeasrcher(new SearchAlgorithmsLib.BFS<T>());
                            break;
                        }
                    case 1:
                        {
                            setSeasrcher(new SearchAlgorithmsLib.DFS<T>());
                            break;
                        }
                    default:
                        break;
                }
                Solution<T> sol = this.searcher.search(getMazeByName(name));
                
                string solutionStr = "";
                List<State<T>> solutionList = sol.getStateList();
                string state = solutionList.Last().ToString();
                solutionList.Remove(solutionList.Last());
                
                string[] arr = state.Split(',');
                int x1,x2,y1,y2;
                x1 = int.Parse(arr[0].Split('(')[1]);
                y1 = int.Parse(arr[1].Split(')')[0]);


                while (solutionList.Count >0)
                {
                    state = solutionList.Last().ToString();
                    arr = state.Split(',');
                    x2 = int.Parse(arr[0].Split('(')[1]);
                    y2 = int.Parse(arr[1].Split(')')[0]);
                    if (x1 > x2)
                    {
                        solutionStr += "3";
                        
                    }
                    if(x1 < x2)
                    {
                        solutionStr += "2";

                    }
                    if (y1 > y2)
                    {
                        solutionStr += "0";
                    }
                    if (y1 < y2)
                    {
                        solutionStr += "1";
                    }
                    x1 = x2;
                    y1 = y2;
                }
                singleGameMaze.Add(getMazeByName(name), );
                JObject solutionObject = new JObject();
                solutionObject["Name"] = name;
                solutionObject["Solution"] = solutionStr; ;
                solutionObject["NodesEvaluated"] = searcher.getNumberOfNodesEvaluated();
                // return solutionObject.ToString();
                this.c.DataHasChanged(solutionObject.ToString(), client);

            }
            return false;
        }

        public bool close(string name, TcpClient client)
        {
            ISearchable<T> searchable = null;
            foreach (KeyValuePair<ISearchable<T>,string> key in gamesNames )
            {
                if (key.Value.Equals(name))
                {
                    searchable = key.Key;
                    break;
                }
            }
            List<TcpClient> clients = this.multiPlayerGame[searchable];
            this.multiPlayerGame[searchable].Clear();
            string msg = "game" + name + "is now closed";
            foreach (TcpClient c  in clients)
            {
                this.c.DataHasChanged(msg, c);
            }
            return false;
        }

        /*public void Solve(IProblem<T> p)
{
throw new NotImplementedException();
}*/
    }
}
