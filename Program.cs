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
            cities.CalculatePath("A", "B", "C");                // #01 - Calcular caminho: ABC
            cities.CalculatePath("A", "D");                     // #02 - Calcular caminho: AD
            cities.CalculatePath("A", "D", "C");                // #03 - Calcular caminho: ADC
            cities.CalculatePath("A", "E", "B", "C", "D");      // #04 - Calcular caminho: AEBCD
            cities.CalculatePath("A", "E", "D");                // #05 - Calcular caminho: AED
            cities.SearchPathsWithNStops(3, "C", "C");          // #06 - Caminhos possíveis C,C com máx. 3 passos
            cities.SearchPathsWithNStops(4, "A", "C", true);    // #07 - Caminhos possíveis A,C com 4 passos
            cities.FindShortestPath("A", "C");                  // 08 - Menor distância de viagem A,C
            cities.FindShortestPath("B", "B");                  // 09 - Menor distância de viagem B,B
            // Obs.: Questão 10 não foi implementada.
            cities.FindAllLoopsGivenLimit("C", 30);             // 10 - Viagens C,C com dist. < 30
        }
    }
}
