using Robus;
using System;
using System.Runtime.CompilerServices;

namespace Robot.TesApp
{
    /// <summary>
    /// The Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main method 
        /// </summary>
        /// <param name="args">the args</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello ! This is a autonomous Robot");
            TestRobotApi();
        }

        /// <summary>
        /// Method to test Robot API 
        /// </summary>
        private static void TestRobotApi()
        {
            RobotTest test = new RobotTest();
            test.TestDrawSquare();
            test.TestReplay();
            Console.ReadLine();
        }
    }
}
