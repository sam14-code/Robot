using Robot.InstructionsReader;
using Robot.Models;
using Robot.RobotInstructionsWriter;
using Robotica;
using Robus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.TesApp
{
    /// <summary>
    /// The RobotTest Class
    /// </summary>
    public class RobotTest
    {
        /// <summary>
        /// variable for robot api 
        /// </summary>
        private RobusApi _api;

        /// <summary>
        /// The writer
        /// </summary>
        private IInstructionsWriter<RobotAction> _writer;

        /// <summary>
        /// The reader
        /// </summary>
        private IInstructionsReader<RobotAction> _reader;

        /// <summary>
        /// creates a new instance of <see cref="RobotTest"/> class
        /// </summary>
        public RobotTest()
        {          
            this._writer = new InstructionsWriter<RobotAction>();
            this._reader = new InstructionsReader<RobotAction>();
            this._api = new RobusApi(this._writer, this._reader);
            this._writer.FileName = this._reader.FileName = @"C:\Test\RobotInstructions.json";
        }

        /// <summary>
        /// This Method tests the draw square 
        /// </summary>
        public void TestDrawSquare()
        {
            Console.WriteLine("Robot started drawing square");
            this._api.DrawSquare<IRobot>(null);
            Console.WriteLine("Robot finished drawing square");
            Console.WriteLine($"Robot Instructions are saved in {this._writer.FileName}");
        }

        /// <summary>
        /// This method tests the replay method
        /// </summary>
        public void TestReplay()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Robot started replaying instructions");
            this._reader.Instructions = this._writer.Instructions;
            this._api.Replay<AIRobot>(null);
            Console.WriteLine("Robot finished replaying instructions");
        }
    }
}
