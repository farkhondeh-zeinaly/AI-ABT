using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABTProject
{
    public class GraphColoring
    {
        int _vertexNo;

        public GraphColoring(int vertexNo)
        {
            _vertexNo = vertexNo;
        }

        int[] color;

        public bool CheckLoacalView(int v, int[][] graph, int[] color, int c)

        {
            for (int i = 0; i < _vertexNo; i++)
            {
                if (graph[v][i] == 1 && c == color[i])
                {
                    Console.WriteLine("     BackTrack...");
                    return false;
                }
            }

            return true;
        }

        public bool HandleOk(int[][] graph, int m, int[] color, int v)
        {
            if (v == _vertexNo)
            {
                return true;
            }

            Console.WriteLine("Checking vertex " + v);

            for (int c = 1; c <= m; c++)
            {
                Console.WriteLine("     Checking color " + c + " for Vertex " + v);
                if (CheckLoacalView(v, graph, color, c))
                {
                    color[v] = c;
                    Console.WriteLine("         Color " + c + " assigned for Vertex " + v + Environment.NewLine);

                    if (HandleOk(graph, m, color, v + 1))
                    {
                        return true;
                    }

                    color[v] = 0;
                }
            }

            return false;
        }

        public bool DoColoring(int[][] graph, int m)
        {
            color = new int[_vertexNo];

            for (int i = 0; i < _vertexNo; i++)
            {
                color[i] = 0;
            }

            if (!HandleOk(graph, m, color, 0))
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }

            PrintSolution(color);
            return true;
        }

        public void PrintSolution(int[] color)
        {
            Console.WriteLine("Solution:");

            for (int i = 0; i < _vertexNo; i++)
            {
                Console.WriteLine("     Vertex " + i + " -> Color: " + color[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
