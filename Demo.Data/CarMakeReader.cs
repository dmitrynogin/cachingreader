using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class CarMakeReader : IReader<CarMakeLookup>
    {
        public CarMakeReader(Func<DemoContext> context) =>
            Context = context;

        Func<DemoContext> Context { get; }

        public async Task<CarMakeLookup> ReadAsync()
        {
            using (var context = Context())
            {
                var carMakes = await context.CarMakes.ToArrayAsync();
                return new CarMakeLookup(
                    carMakes.Select(cm => (cm.Id, cm.Name)));
            }
        }
    }
}
