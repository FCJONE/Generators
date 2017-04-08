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


            var constGenerator = new ConstGeneratorFabric().Generator(intValue);
            var counterGenerator = new CounterGeneratorFabric().Generator(intValue);


            Console.WriteLine(@"Constant : {0}", constGenerator.Next);
            Console.WriteLine(@"Counter: {0}", counterGenerator.Next);

            Console.ReadKey();
        }


    }





    /// <summary>
    /// Interface of Generator.
    /// </summary>
    internal interface IGenerator
    {
        int Next { get; }
    }

    /// <summary>
    /// Interface of Fabric of Generators.
    /// </summary>
    /// <typeparam name="T">Type of Generator (Const or Counter).</typeparam>
    internal interface IGeneratorFabric<out T>
    {
        T Generator(int inputValue);
    }






    /// <summary>
    /// Constant int generator. Field "Next" contains constant, which was submitted to it.
    /// </summary>
    internal class ConstGenerator
    {
        /// <summary>
        /// Contains generated value, which is next to inputted Value.
        /// </summary>
        public int Next { get; }
        
        /// <param name="inputValue">Value to generate and hold into "Next" field.</param>
        public ConstGenerator(int inputValue = 0)
        {
            Next = inputValue;
        }
    }

    /// <summary>
    /// Counter int generator. Field "Next" contains number, which is next to submitted int.
    /// </summary>
    internal class CounterGenerator
    {
        /// <summary>
        /// Contains constant value, which is inpputed on CounterGenerator instance creation.
        /// </summary>
        public int Next => ++_next;

        private int _next;

        /// <param name="inputValue">Value to generate and hold into "Next" field.</param>
        public CounterGenerator(int inputValue = 0)
        {
            _next = inputValue;
        }
    }






    /// <summary>
    /// Fabric of Const Generators.
    /// </summary>
    internal class ConstGeneratorFabric : IGeneratorFabric<ConstGenerator>
    {
        /// <summary>
        /// Constant generator.
        /// </summary>
        /// <param name="inputValue">Input value.</param>
        /// <returns>Instance of constant generator.</returns>
        public ConstGenerator Generator(int inputValue)
        {
            return new ConstGenerator(inputValue);
        }
    }

    /// <summary>
    /// Fabric of Counter Generators.
    /// </summary>
    internal class CounterGeneratorFabric : IGeneratorFabric<CounterGenerator>
    {
        /// <summary>
        /// Counter generator.
        /// </summary>
        /// <param name="inputValue">Input value.</param>
        /// <returns>Instance of counter generator.</returns>
        public CounterGenerator Generator(int inputValue)
        {
            return new CounterGenerator(inputValue);
        }
    }
}