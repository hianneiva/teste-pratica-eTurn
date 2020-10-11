using System;
using System.Collections.Generic;
using System.Linq;
using testePraticaETurn.Model;

namespace testePraticaETurn.Service
{
    ///<summary>
    /// Class that will implement all operations performed by the program.
    ///</summary>
    public static class Utils
    {
        private static readonly IDictionary<string, int> CITY_INDEXES = new Dictionary<string, int>()
        {
            {"A", 0},
            {"B", 1},
            {"C", 2},
            {"D", 3},
            {"E", 4},
        };

        ///<summary>
        /// The method that will populate all cities for the scenarios proposed.
        ///</summary>
        ///<returns>A populated list of cities.</returns>
        public static IList<City> Populate()
        {
            List<City> cities = new List<City>();

            /**
             * Cidade A:
             * A => B: 5;
             * A => D: 5;
             * A => E: 7;
             */
            City a = new City("A");
            a.AddPath("B", 5).AddPath("D", 5).AddPath("E", 7);
            cities.Add(a);

            /**
             * Cidade B:
             * B => C: 4;
             */
            City b = new City("B");
            b.AddPath("C", 4);
            cities.Add(b);

            /**
             * Cidade C:
             * C => D: 8;
             * C => E: 2;
             */
            City c = new City("C");
            c.AddPath("D", 8).AddPath("E", 2);
            cities.Add(c);

            /**
             * Cidade D:
             * D => C: 8;
             * D => E: 6;
             */
            City d = new City("D");
            d.AddPath("C", 8).AddPath("E", 6);
            cities.Add(d);

            /**
             * Cidade E:
             * E => B: 3;
             */
            City e = new City("E");
            e.AddPath("B", 3);
            cities.Add(e);

            return cities;
        }

        ///<summary>
        /// The method that will calculate methods between cities.
        ///</summary>
        ///<param name="cities">The cities which path will be calculated on.</param>
        ///<param name="name">The path to be calculated as an array of strings.</param>
        public static void CalculatePath(this IList<City> cities, params string[] pathDescription)
        {
            try
            {
                City current = cities.FirstOrDefault(city => pathDescription[0].Equals(city.Name));
                int totalRota = 0;

                for (int i = 1; i < pathDescription.Length; i++)
                {
                    if (current == null || !(current?.Paths.ContainsKey(pathDescription[i])).GetValueOrDefault())
                    {
                        throw new Exception("Rota não existente");
                    }

                    totalRota += current.Paths[pathDescription[i]];
                    current = cities.FirstOrDefault(city => pathDescription[i].Equals(city.Name));
                }

                Console.WriteLine(totalRota);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ///<summary>
        /// The method that will search paths with N stops, exactly or at most.
        ///</summary>
        ///<param name="cities">The cities which paths will be searched on.</param>
        ///<param name="steps">The number of steps for the searched path.</param>
        ///<param name="start">The first city in the path.</param>
        ///<param name="end">The last city in the path.</param>
        ///<param name="strict"><c>true</c> if it s strictly with N steps, false if it is N steps at most.</param>
        public static void SearchPathsWithNStops(this IList<City> cities, int steps, string start, string end, bool strict = false)
        {
            int[,] connectionMatrix = BuildPathBasicMatrix(cities);

            if (strict)
            {
                int[,] pathMatrix = MatrixPower(connectionMatrix, steps);
                Console.WriteLine(pathMatrix[CITY_INDEXES[start], CITY_INDEXES[end]]);
            }
            else
            {
                IList<int[,]> pathMatrixes = new List<int[,]>();
                pathMatrixes.Add(connectionMatrix);

                for (int i = 2; i <= steps; i++)
                {
                    pathMatrixes.Add(MatrixPower(connectionMatrix, i));
                }

                int pathNumbers = pathMatrixes.Sum(pathMatrix => pathMatrix[CITY_INDEXES[start], CITY_INDEXES[end]]);
                Console.WriteLine(pathNumbers);
            }
        }

        ///<summary>
        /// The method that will find the shortest path between two cities.
        /// Note: Dijkstra's algorithm assume self distance as always 0 (Zero distance),
        /// because of that, self distances are set by calculating the minimal distance that's not zero.
        ///</summary>
        ///<param name="cities">The cities which paths will be searched on.</param>
        ///<param name="start">The first city in the path.</param>
        ///<param name="end">The last city in the path.</param>
        public static void FindShortestPath(this IList<City> cities, string start, string end)
        {
            if (!start.Equals(end))
            {
                int[,] weighedMatrix = BuildPathMatrix(cities);
                int[] distances = Dijkstra(weighedMatrix, CITY_INDEXES[start]);
                Console.WriteLine(distances[CITY_INDEXES[end]]);
            }
            else
            {
                int distance = 0;
                City city = cities.FirstOrDefault(c => start.Equals(c.Name));

                do
                {
                    KeyValuePair<string, int> next =
                        city.Paths.Aggregate((path, nextPath) => path.Value < nextPath.Value ? path : nextPath);
                    distance += next.Value;
                    city = cities.FirstOrDefault(c => next.Key.Equals(c.Name));
                } while (!end.Equals(city.Name));

                Console.WriteLine(distance);
            }
        }

        private static int[,] BuildPathBasicMatrix(IList<City> cities)
        {
            int matrixSize = cities.Count;
            int[,] matrix = BuildPathMatrix(cities);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = matrix[i, j] > 0 ? 1 : 0;
                }
            }

            return matrix;
        }

        /**
         * For reference: A = 0, B = 1, C = 2, D = 3, E = 4.
         */
        private static int[,] BuildPathMatrix(IList<City> cities)
        {
            int matrixSize = cities.Count;
            int[,] adjacencyMatrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                City city = cities[i];

                if (city.Paths.ContainsKey("A"))
                {
                    adjacencyMatrix[i, 0] = city.Paths["A"];
                }
                if (city.Paths.ContainsKey("B"))
                {
                    adjacencyMatrix[i, 1] = city.Paths["B"];
                }
                if (city.Paths.ContainsKey("C"))
                {
                    adjacencyMatrix[i, 2] = city.Paths["C"];
                }
                if (city.Paths.ContainsKey("D"))
                {
                    adjacencyMatrix[i, 3] = city.Paths["D"];
                }
                if (city.Paths.ContainsKey("E"))
                {
                    adjacencyMatrix[i, 4] = city.Paths["E"];
                }
            }

            return adjacencyMatrix;
        }

        private static int[,] SquareMatrixMultiplication(int[,] a, int[,] b)
        {
            int size = a.GetLength(0);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        private static int[,] MatrixPower(int[,] matrix, int power)
        {
            int[,] current = matrix;

            for (int i = 1; i < power; i++)
            {
                current = SquareMatrixMultiplication(current, matrix);
            }

            // PrintSquareMatrix(current);
            return current;
        }

        private static int MinDistance(int[] distance, bool[] shortestPathTreeSet, int verticesTotal)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < verticesTotal; i++)
                if (shortestPathTreeSet[i] == false && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }

            return minIndex;
        }

        private static int[] Dijkstra(int[,] graph, int source)
        {
            int verticesTotal = graph.GetLength(0);
            int[] distance = new int[verticesTotal];
            bool[] shortestPathTreeSet = new bool[verticesTotal];

            for (int i = 0; i < verticesTotal; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesTotal - 1; count++)
            {
                int u = MinDistance(distance, shortestPathTreeSet, verticesTotal);
                shortestPathTreeSet[u] = true;

                for (int i = 0; i < verticesTotal; i++)
                    if (!shortestPathTreeSet[i] &&
                        graph[u, i] != 0 &&
                        distance[u] != int.MaxValue &&
                        distance[u] + graph[u, i] < distance[i])
                    {
                        distance[i] = distance[u] + graph[u, i];
                    }
            }

            return distance;
        }

        private static void PrintSquareMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            Console.WriteLine("===========");

            for (int i = 0; i < size; i++)
            {
                Console.Write("|");

                for (int j = 0; j < size; j++)
                {
                    Console.Write(j + 1 < size ? $"{ matrix[i, j] } " : $"{ matrix[i, j] }");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("===========");
        }
    }
}