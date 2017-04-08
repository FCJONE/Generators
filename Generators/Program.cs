using System;

namespace Generators
{
    internal class Program
    {


        /// <summary>
        /// Main program.
        /// </summary>
        private static void Main()
        {
            int intValue;

            Console.Write(@"Type in integer value: ");

            while (!int.TryParse(Console.ReadLine(), out intValue))
            {
                /*Do nothing*/
            }

            Console.WriteLine(@"Constant : {0}", new ConstGeneratorFabric().Generator(intValue).Next);
            Console.WriteLine(@"Counter: {0}", new CounterGeneratorFabric().Generator(intValue).Next);

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

    internal interface IGeneratorFabric<out T>
    {
        T Generator(int inputValue);
    }






    /// <summary>
    /// Generators of integer value.
    /// </summary>
    internal class ConstGenerator
    {
        public int Next { get; }

        public ConstGenerator(int inputValue)
        {
            Next = inputValue;
        }
    }

    internal class CounterGenerator
    {
        private int _next;
        public int Next => _next++;

        public CounterGenerator(int inputValue = 0)
        {
            _next = inputValue;
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