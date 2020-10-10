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


        ///<summary>
        /// The method that will populate all cities for the scenarios proposed.
        ///</summary>
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
    }
}