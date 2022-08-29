using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace PathFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph worldMap = new Graph(new List<Node>()
            { new Node(new List<int>(){1,4,5}),
              new Node (new List<int>(){0,2}),
              new Node (new List<int>(){1,3, 6}),
              new Node (new List<int>(){2,5}),
              new Node (new List<int>(){0}),
              new Node (new List<int>(){0,3,6}),
              new Node (new List<int>(){2,5}) 
            });

            Console.WriteLine(worldMap.FindAPath(0, 3));
        }
    }
}
