using Autofac;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.Register(ctx => new DemoContext())
                .AsSelf();

            builder.Register(ctx => 
                new CarMakeReader(ctx.Resolve<Func<DemoContext>>()).Cache())
                .SingleInstance()
                .AsImplementedInterfaces();

            var container = builder.Build();

            var reader1 = container.Resolve<IReader<CarMakeLookup>>();
            var lookup1 = reader1.ReadAsync();

            var reader2 = container.Resolve<IReader<CarMakeLookup>>();
            var lookup2 = reader2.ReadAsync();

            Console.WriteLine(
                ReferenceEquals(lookup1, lookup2));
        }
    }
}
