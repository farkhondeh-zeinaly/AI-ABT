using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABTProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("----------------------------------");
            Console.WriteLine("--- ABT graph coloring problem ---");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            int vertexCount = 0;

            while (vertexCount < 1)
            {
                Console.WriteLine("Vertexes count:");
                try
                {
                    vertexCount = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            int[][] graph = new int[vertexCount][];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[vertexCount];
            }


            Console.WriteLine("If vertex i has link with vertex j enter 1 othervise 0:");

            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (i == j)
                    {
                        graph[i][j] = 0;
                    }
                    else
                    {
                        int hasLink = -1;
                        while (!(hasLink == 0 || hasLink == 1))
                        {
                            Console.WriteLine(i + " -> " + j + "  ?");
                            try
                            {
                                hasLink = Convert.ToInt32(Console.ReadLine());
                                if (hasLink >= 0 && hasLink <= 1)
                                {
                                    graph[i][j] = hasLink;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                }
            }


            Console.WriteLine("Graph:");

            for (int i = 0; i < vertexCount; i++)
            {
                Console.Write("      |");

                for (int j = 0; j < vertexCount; j++)
                {
                    Console.Write(graph[i][j] + "|");
                }

                Console.Write(Environment.NewLine);
            }

            int colorsCount = 0;

            while (colorsCount < 1)
            {
                Console.WriteLine("Colors count:");
                try
                {
                    colorsCount = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Operation starts...");


            GraphColoring coloring = new GraphColoring(vertexCount);


            //int[][] graph = new int[][]
            //{
            //             new int[] {0,1,1,1},
            //             new int[] {1,0,1,0},
            //             new int[] {1,1,0,1},
            //             new int[] {1,0,1,0},
            //};

            coloring.DoColoring(graph, colorsCount);

            Console.ReadLine();
        }
    }
}
