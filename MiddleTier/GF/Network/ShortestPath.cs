using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF;

namespace Horizon4.GF.Network
{
    public enum ShortestPathMethod
    {
        DijkstraSearch = 1,
        AStar = 2
    }

    public class Node : Location
    {
        //Gets or sets whether a node has been visited during calculation
        public bool Visited { get; set; }
        public double? MinCostToStart { get; set; }
        public Node NearestToStart { get; set; }
        public Path Path { get; set; }

        public Node(Location Location) : base(Location.ID)
        {
        }

        #region Methods

        public PathCollection GetLocationPaths(YMDV YMDV)
        {
            return new PathCollection(this, YMDV);
        }
        
        #endregion Methods  
    }

    public static class ShortestPath
    {
        static Node StartNode;
        static Node EndNode;
        static double ShortestPathLength;
        static List<Node> ProcessList;
        private static int _NodeVisits;

        public static int NodeVists { get { return _NodeVisits; } }

        public static List<Node> Calculate(Location Start, Location End, YMDV YMDV, ShortestPathMethod Method)
        {
            StartNode = new Node(Start);
            EndNode = new Node(End);
            
            //Execute Search       
            if (Method == ShortestPathMethod.DijkstraSearch)
            {
                DijkstraSearch(YMDV);
            }
            else
            {
                AStar(YMDV);
            }

            //Set up List of Nodes
            List<Node> ShortestPathList = new List<Node>();

            //Reset End Nodes
            EndNode = ProcessList.Find(x => x.ID == EndNode.ID);

            //Add End Node
            ShortestPathList.Add(EndNode);

            BuildShortestPath(ShortestPathList, EndNode, YMDV);

            //Reverse List
            ShortestPathList.Reverse();

            return ShortestPathList;
        }

        private static Location GetLocationFromNode(Node Node)
        {
            return new Location(Node.ID);
        }

        private static void BuildShortestPath(List<Node> List, Node Node, YMDV YMDV)
        {
            if (Node.NearestToStart == null)
                return;
            List.Add(Node.NearestToStart);
            if (Node.GetLocationPaths(YMDV).Count(x => ProcessList.Find(y => y.ID == x.End.ID).ID == Node.NearestToStart.ID) != 0)
            {
                ShortestPathLength += Node.GetLocationPaths(YMDV).Single(x => ProcessList.Find(y => y.ID == x.End.ID).ID == Node.NearestToStart.ID).StraighLineDistance;
            }//ShortestPathCost += Node.Connections.Single(x => x.ConnectedNode == node.NearestToStart).Cost;
            BuildShortestPath(List, Node.NearestToStart, YMDV);
        }

        private static void AStar(YMDV YMDV)
        {
            StartNode.MinCostToStart = 0;
            List<Node> PriorityQueue = new List<Node>();
            PriorityQueue.Add(StartNode);
            ProcessList = new List<Node>();
            _NodeVisits = 0;
            Location EndLocation = GetLocationFromNode(EndNode);

            do
            {
                _NodeVisits++;
                PriorityQueue = PriorityQueue.OrderBy(x => x.MinCostToStart).ToList();
                Node WorkingNode = PriorityQueue.First();
                PriorityQueue.Remove(WorkingNode);

                foreach (Path WorkingPath in WorkingNode.GetLocationPaths(YMDV).OrderBy(x => x.StraighLineDistance + Math.Abs(x.Start.Distance(EndLocation))))
                {
                    Node ChildNode;

                    if (ProcessList.Count(x => x.ID == WorkingPath.End.ID) == 0)
                    {
                        ChildNode = new Node(WorkingPath.End);
                        ProcessList.Add(ChildNode);
                    }
                    else
                    {
                        ChildNode = ProcessList.Find(x => x.ID == WorkingPath.End.ID);
                    }

                    if (ChildNode.Visited)
                        continue;
                    if (ChildNode.MinCostToStart == null || ChildNode.MinCostToStart + WorkingPath.StraighLineDistance < ChildNode.MinCostToStart)
                    {
                        ChildNode.MinCostToStart = ChildNode.MinCostToStart == null ? WorkingPath.StraighLineDistance : ChildNode.MinCostToStart + WorkingPath.StraighLineDistance;
                        ChildNode.NearestToStart = WorkingNode;
                        if (!PriorityQueue.Contains(ChildNode))
                            PriorityQueue.Add(ChildNode);
                    }
                }
                WorkingNode.Visited = true;
                if (WorkingNode == EndNode)
                    return;
            } while (PriorityQueue.Any());
        }


        private static void DijkstraSearch(YMDV YMDV)
        {
            StartNode.MinCostToStart = 0;
            List<Node> PriorityQueue = new List<Node>();
            PriorityQueue.Add(StartNode);
            ProcessList = new List<Node>();
            _NodeVisits = 0;

            do
            {
                _NodeVisits++;
                PriorityQueue = PriorityQueue.OrderBy(x => x.MinCostToStart).ToList();
                Node WorkingNode = PriorityQueue.First();
                PriorityQueue.Remove(WorkingNode);

                foreach (Path WorkingPath in WorkingNode.GetLocationPaths(YMDV).OrderBy(x => x.StraighLineDistance))
                {
                    Node ChildNode;

                    if (ProcessList.Count(x => x.ID == WorkingPath.End.ID) == 0)
                    {
                        ChildNode = new Node(WorkingPath.End);
                        ProcessList.Add(ChildNode);
                    }
                    else
                    {
                        ChildNode = ProcessList.Find(x => x.ID == WorkingPath.End.ID);
                    }
                    
                    if (ChildNode.Visited)
                        continue;
                    if (ChildNode.MinCostToStart == null || ChildNode.MinCostToStart + WorkingPath.StraighLineDistance < ChildNode.MinCostToStart)
                    {
                        ChildNode.MinCostToStart = ChildNode.MinCostToStart == null ? WorkingPath.StraighLineDistance : ChildNode.MinCostToStart + WorkingPath.StraighLineDistance;
                        ChildNode.NearestToStart = WorkingNode;
                        ChildNode.Path = WorkingPath;

                        if (!PriorityQueue.Contains(ChildNode))
                        {
                            PriorityQueue.Add(ChildNode);
                        }
                    }
                }
                WorkingNode.Visited = true;
                if (WorkingNode == EndNode)
                    return;
            } while (PriorityQueue.Any());
        }
    }

}
