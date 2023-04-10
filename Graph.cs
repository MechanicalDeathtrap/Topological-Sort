using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Topological_Sort
{
    internal class Graph
    {
        private int vertexes;
        private List<List<int>> adjacency;

        public Stopwatch time = new Stopwatch();
        int iteration = 0;

        public Graph(int Vertexes)
        {
            vertexes = Vertexes;
            adjacency = new List<List<int>>();
            for (int i = 0; i < Vertexes; i++)
                adjacency.Add(new List<int>());
        }

        public void AddEdge(int u, int v) => adjacency[u].Add(v); 

        private void MainTopologicalSort( Stack<int> stack, int vertexes, bool[] isVertexVisited )
        {
            isVertexVisited[vertexes] = true;

            foreach (var vertex in adjacency[vertexes])
            {
                iteration++;
                if (!isVertexVisited[vertex]) MainTopologicalSort(stack, vertex, isVertexVisited);
            }

            stack.Push(vertexes);
        }

        public Stack<int> TopologicalSort(out int timef, out int iterations)
        {
            time.Start();
            var stack = new Stack<int>();
            var visited = new bool[vertexes];

            for (int i = 0; i < vertexes; i++)
            {
                iteration++;
                if (!visited[i]) MainTopologicalSort(stack, i, visited);
            }

            time.Stop();
            timef = (int)time.ElapsedTicks;
            iterations = iteration;
            return stack;
        }
    }
}

