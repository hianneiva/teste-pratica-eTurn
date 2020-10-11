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
            cities.CalculatePath("A", "B", "C");                // #01
            cities.CalculatePath("A", "D");                     // #02
            cities.CalculatePath("A", "D", "C");                // #03
            cities.CalculatePath("A", "E", "B", "C", "D");      // #04
            cities.CalculatePath("A", "E", "D");                // #05
            cities.SearchPathsWithNStops(3, "C", "C");          // #06
            cities.SearchPathsWithNStops(4, "A", "C", true);    // #07
        }
    }
}
