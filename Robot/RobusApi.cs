using Robot;
using Robot.InstructionsReader;
using Robot.Models;
using Robot.RobotInstructionsWriter;
using Robotica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Robus
{
    /// <summary>
    /// The Robot API class
    /// </summary>
    public class RobusApi
    {
        /// <summary>
        /// The Writer 
        /// </summary>
        private IInstructionsWriter<RobotAction> _instructionWriter;

        /// <summary>
        /// The reader variable 
        /// </summary>
        private IInstructionsReader<RobotAction> _instructionReader; 

        /// <summary>
        /// creates a instance of <see cref="RobusApi"/> class
        /// </summary>
        /// <param name="robotInstructionsWriter"></param>
        /// <param name="robotInstructionsReader"></param>
        public RobusApi(IInstructionsWriter<RobotAction> robotInstructionsWriter, IInstructionsReader<RobotAction> robotInstructionsReader)
        {
            this._instructionWriter = robotInstructionsWriter;
            this._instructionReader = robotInstructionsReader; 
        }

        /// <summary>
        /// Function to draw a square 
        /// </summary>
        /// <typeparam name="TRobot">The Robot</typeparam>
        public void DrawSquare<TRobot>(IRobot robot) where TRobot : IRobot
        {
            try
            {
                if (robot == null)
                {
                    // Used this only for testing via console app. 
                    robot = Activator.CreateInstance<AIRobot>();
                }

                robot.Move(10, 1);
                this._instructionWriter.AddInstruction(RobotActionType.Move, new Move(10, 1));

                robot.Rotate(90);
                this._instructionWriter.AddInstruction(RobotActionType.Rotate, new Rotate(90));

                robot.Move(20, 2);
                this._instructionWriter.AddInstruction(RobotActionType.Move, new Move(20, 2));

                robot.Rotate(80);
                this._instructionWriter.AddInstruction(RobotActionType.Rotate, new Rotate(80));

                robot.Move(30, 3);
                this._instructionWriter.AddInstruction(RobotActionType.Move, new Move(30, 3));

                robot.Rotate(70);
                this._instructionWriter.AddInstruction(RobotActionType.Rotate, new Rotate(70));

                robot.Move(40, 4);
                this._instructionWriter.AddInstruction(RobotActionType.Move, new Move(40, 4));

                // Save all the instructions to file
                this._instructionWriter.SaveAllInstructionsToFile();
            }
            catch (Exception)
            {
                throw;
            }
        }
                
        /// <summary>
        /// Replay's all the previous executed robot instructions 
        /// </summary>
        /// <typeparam name="TRobot"></typeparam>
        public void Replay<TRobot>(IRobot robot) where TRobot : IRobot
        {
            try
            {
                if (this._instructionReader != null)
                {
                    this._instructionReader.ReadInstructionsFromFile();

                    if (this._instructionReader.Instructions != null && this._instructionReader.Instructions.Count > 0)
                    {
                        Type t = typeof(TRobot);
                        Object r = robot;
                        if (robot == null)
                        {
                            r = Activator.CreateInstance<TRobot>();
                        }

                        foreach (var instruction in this._instructionReader.Instructions)
                        {
                            Type argsType = instruction.Parameters.GetType();
                            List<Object> args = new List<object>();
                            foreach (var property in argsType.GetProperties())
                            {
                                args.Add(property.GetValue(instruction.Parameters));
                            }

                            t.InvokeMember(instruction.ActionType.ToString(), BindingFlags.Instance | BindingFlags.InvokeMethod |
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic, null, r, args.ToArray());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
