using System;
using System.Collections.Generic;

namespace Calculator.BL
{
    public static class Program
    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        internal static void Main()
        {
            ContextOperation context;
            double result = 0;

            // Tres contextos con diferentes estrategias
            context = new ContextOperation();
            result = context.Sum(new List<double>() { 2, 3, 5, 6 });
            Console.WriteLine(result.ToString());

            // Tres contextos con diferentes estrategias
            context = new ContextOperation();
            result = context.Diff(2, 3);
            Console.WriteLine(result.ToString());

            // Tres contextos con diferentes estrategias
            context = new ContextOperation();
            result = context.Multiply(new List<double>() { 2, 3, 8 });
            Console.WriteLine(result.ToString());

            Console.ReadKey();
        }
    }

}
