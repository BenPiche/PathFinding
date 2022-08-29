using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    // 1,2
    internal class Node
    {
        private List<int> neighbors = new List<int>();
        public List<int> Neighbors
        { 
            get
            { 
                List<int> temp = new List<int>();
                foreach (var neighbor in neighbors)
                {
                    temp.Add(neighbor);
                }
                return temp;
            }
            private set 
            {
                neighbors = value; 
            }
        }
        public Node(List<int> neighbors)
        {
            Neighbors = neighbors;
        }

    }

    internal class Graph
    {
        private List<Node> nodes = new List<Node>();
        public List<Node> Nodes
        {
            get 
            {
                List<Node> list = new List<Node>();
                foreach(Node node in nodes)
                {
                    list.Add(node);
                }
                return list;
                    
            }
            private set { nodes = value; }
        }
        public Graph(List<Node> nodes)
        {
            Nodes = nodes;
        }
        
        public string FindAPath(int startIndex, int targetIndex)
        {
            List<int> toExplore = new List<int>(){};
            toExplore.Add(startIndex);
            bool targetFound = false;

            int[] cameFrom = new int[nodes.Count];

            for (int i = 0; i< cameFrom.Length;i++ )
                cameFrom[i] = -1;

            cameFrom[startIndex] = startIndex;

            while (toExplore.Count > 0 && !targetFound)
            {
                int currentIndex = toExplore[0];
                foreach(int neighbour in Nodes[currentIndex].Neighbors)
                {
                    if (cameFrom[neighbour]==-1)
                    {
                        toExplore.Add(neighbour);
                        cameFrom[neighbour] = currentIndex;

                        if (neighbour == targetIndex)
                        {
                            targetFound = true;
                            break;
                        }
                    }
                }
                toExplore.RemoveAt(0);
            }

            if(cameFrom[targetIndex] == -1)
            {
                return "no path found";
            }


            string path = "";
            int target = targetIndex;
            while (target != startIndex)
            {
                path += $"{target} - ";
                target = cameFrom[target];
            }
            path += $"{target}";
            char[] foundPath = path.ToCharArray();
            Array.Reverse(foundPath);



            return new string(foundPath);
        }
    }
}
