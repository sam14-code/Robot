using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.InstructionsReader
{
    /// <summary>
    /// The Instructions reader class
    /// </summary>
    /// <typeparam name="T">the generic type</typeparam>
    public interface IInstructionsReader<T> : IDisposable where T : RobotAction
    {
        /// <summary>
        /// Gets or set the Instructions variable
        /// </summary>
        List<Instruction<T>> Instructions { get; set; }

        /// <summary>
        /// gets or sets the fileName to save the location
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Read Next Instruction from memory
        /// </summary>
        /// <returns></returns>
        Instruction<T> ReadandExecuteNextInstruction();

        /// <summary>
        /// Read all instructions from file
        /// </summary>
        /// <returns></returns>
        void ReadInstructionsFromFile();
    }
}
