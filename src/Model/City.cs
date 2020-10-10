using System.Collections.Generic;
using System.Linq;

namespace testePraticaETurn.Model
{
    ///<summary>
    /// The model for the cities and the distances involved.
    ///</summary>
    public class City
    {
        ///<summary>
        /// The City name.
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// The distance between the city and others.
        ///</summary>
        public IDictionary<string, int> Paths { get; private set; }

        ///<summary>
        /// Constructor.
        ///</summary>
        public City(string name)
        {
            Name = name;
            Paths = new Dictionary<string, int>();
        }

        ///<summary>
        /// Allows a path to be added to the city.
        ///</summary>
        public City AddPath(string name, int distance)
        {
            Paths.Add(name, distance);
            return this;
        }

        ///<summary>
        /// Displays city information formatted as text.
        ///</summary>
        public override string ToString() =>
            $"Name: { Name }. Paths: [{ Paths.Select(path => $"{ path.Key }, { path.Value };") }]";
    }
}