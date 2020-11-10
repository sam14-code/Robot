using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Robot.RobotInstructionsWriter
{
    /// <summary>
    /// The Instructions writer interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInstructionsWriter<T> : IDisposable where T : RobotAction
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
        /// add robot instruction to instructions list 
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="action"></param>
        void AddInstruction(RobotActionType actionType, T action);

        /// <summary>
        /// Save all instructions to file in a single go
        /// </summary>
        /// <returns>nothing </returns>
        void SaveAllInstructionsToFile(); 
    }
}
