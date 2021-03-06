using System;
using System.Windows.Forms;

namespace C000UnitConverter
{
    /// <summary>
    /// Main class of the program, also includes calculation functions
    /// </summary>
    public static class C000
    {
        private readonly static decimal[] cfM = { 1.0m, 453.59237m, 28.3495231m };
        private readonly static decimal[] cfL = { 1.0m, 0.0254m, 0.3048m, 0.9144m, 1609.344m};
        private readonly static decimal[] cfA = { 1.0m, 0.00064516m, 0.009290304m, 0.83612736m, 2589988.110336m };
        private readonly static decimal[] cfV = { 1.0m, 0.0000016387064m, 0.000454609m, 0.028316846592m, 0.001m };
        private readonly static decimal[] cfS = { 1.0m, 0.27m, 0.44704m, 0.3048m };
        private readonly static decimal[][] cf = { cfM, cfL, cfA, cfV, cfS };

        /// <summary>
        /// Returns an array with values in different units 
        /// </summary>
        /// <param name="val">Original value</param>
        /// <param name="i">Index of original value in coefficient array</param>
        /// <param name="q">Index of physical quantity in coefficient array array, 0 = mass, 1 = length, 2 = area, 3 = volume, 4 = speed</param>
        /// <param name="exp">Scientific notation of the metric unit (i = 0)</param>
        /// <returns></returns>
        public static decimal[] Calc(decimal val, int i, int q, double exp)
        {
            if (q == 2 ^ q == 3) exp *= q;
            if (i == 0 && exp != 1)
            {
                try
                {
                    val *= (decimal)System.Math.Pow(10.0d, exp);
                }
                catch ( OverflowException e )
                {
                    val = decimal.MaxValue;
                }
            }
            decimal[] result = new decimal[cf[q].Length];
            for (int j = 0; j < result.Length; j++)
            {
                try
                {
                    result[j] = val * cf[q][i] / cf[q][j];
                }
                catch (OverflowException e)
                {
                    result[j] = decimal.MaxValue;
                }
            }
            if (exp != 1) result[0] *= (decimal)System.Math.Pow(10.0d, -exp);
            return result;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new C000Window());
        }
    }
}