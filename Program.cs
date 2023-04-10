using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Topological_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TopologicalSortForFile("graphs36.txt", "output36.txt", "info36.txt");
        }
        public static void TopologicalSortForFile(string _input, string _output, string _info)
        {
            StreamReader input = new StreamReader(_input);
            StreamWriter output = new StreamWriter(_output);
            StreamWriter info = new StreamWriter(_info);

            int time;
            int iterations;
            string[] file;
            info.WriteLine(" Time " + "  " + " Iterations ");

            while (!input.EndOfStream)
            {
                file = input.ReadLine().Split('-');
                Graph graph = new Graph(int.Parse(file[0]));

                for (int i = 1; i < file.Length; i++)
                {
                    var fil = file[i].Replace('[', ' ').Replace(']', ' ').Trim();
                    var vertexes = fil.Split(new string[] { ", " }, StringSplitOptions.None);
                    foreach (var vertex in vertexes)
                    {
                        Console.WriteLine(vertex);
                    }
                    graph.AddEdge(int.Parse(vertexes[0]), int.Parse(vertexes[1]));
                }

                var sorted = graph.TopologicalSort(out time, out iterations).ToArray();

                info.WriteLine(time + " , " + iterations);

                output.Write('{');
                for (int i = 0; i < sorted.Length; i++)
                {
                    if (i + 1 == sorted.Length)
                        output.Write(sorted[i]);
                    else
                        output.Write(sorted[i] + " , ");
                }

                output.Write('}');
                output.WriteLine();

            }
            output.Close();
            input.Close();
            info.Close();

        }
    }
}
