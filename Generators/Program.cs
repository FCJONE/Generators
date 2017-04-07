
using System;

namespace Generators
{
    internal class Program
    {
        private static void Main()
        {
            int intValue;

             while (!int.TryParse(Console.ReadLine(), out intValue)) { /*Do nothing*/}

            Console.WriteLine(@"Constant : {0}", new ConstGeneratorFabric().Generator(intValue).Next);
            Console.WriteLine(@"Constant : {0}", new CounterGeneratorFabric().Generator(intValue).Next);

            Console.ReadKey();
        }
    }


    /// <summary>
    /// Interfaces of Generators and Fabrics.
    /// </summary>
    internal interface IGenerator
    {
        int Next { get; }
    }
    internal interface IGeneratorFabric<out T> where T : class
    {
        T Generator(int inputValue);
    }

    /// <summary>
    /// Generators of integer value.
    /// </summary>
    internal class ConstGenerator
    {
        public readonly int Next;

        public ConstGenerator(int inputValue)
        {
            Next = inputValue;
        }
    }
    internal class CounterGenerator
    {
        public readonly int Next;

        public CounterGenerator(int inputValue)
        {
            Next = inputValue + 1;
        }
    }


    /// <summary>
    /// Fabrics of Generators.
    /// </summary>
    internal class ConstGeneratorFabric : IGeneratorFabric<ConstGenerator>
    {
        public ConstGenerator Generator(int inputValue)
        {
            return new ConstGenerator(inputValue);
        }
    }
    internal class CounterGeneratorFabric : IGeneratorFabric<CounterGenerator>
    {
        public CounterGenerator Generator(int inputValue)
        {
            return new CounterGenerator(inputValue);
        }
    }
}
