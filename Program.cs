using System.Collections.Generic;
using testePraticaETurn.Model;

using static testePraticaETurn.Service.Utils;

namespace testePraticaETurn
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<City> cities = Populate();
            cities.CalculatePath("A", "B", "C");
            cities.CalculatePath("A", "D");
            cities.CalculatePath("A", "D", "C");
            cities.CalculatePath("A", "E", "B", "C", "D");
            cities.CalculatePath("A", "E", "D");
        }
    }
}
