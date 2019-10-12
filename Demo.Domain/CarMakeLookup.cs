using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class CarMakeLookup
    {
        public CarMakeLookup(IEnumerable<(int Id, string Make)> data)
        {
            Makes = data.ToDictionary(d => d.Id, d => d.Make);
            Ids = data.ToDictionary(d => d.Make, d => d.Id);
        }

        public IReadOnlyDictionary<int, string> Makes { get; }
        public IReadOnlyDictionary<string, int> Ids { get; }
    }
}