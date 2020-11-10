using Newtonsoft.Json;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Robot.RobotInstructionsWriter
{
    /// <summary>
    /// The Instruction Writer
    /// </summary>
    /// <typeparam name="T">the generic type</typeparam>
    public class InstructionsWriter<T> : IInstructionsWriter<T> where T: RobotAction
    {   
        /// <summary>
        /// The Instructions vairable
        /// </summary>
        private List<Instruction<T>> _instructions;
        
        /// <summary>
        /// The dispose Value
        /// </summary>
        private bool _disposedValue;
        
        /// <summary>
        /// The jsonSerializer
        /// </summary>
        private JsonSerializer _jsonSerializer;

        /// <summary>
        /// creates a new instance of <see cref="InstructionsWriter"/> class
        /// </summary>
        public InstructionsWriter()
        {
            this._instructions = new List<Instruction<T>>();
            this._jsonSerializer = new JsonSerializer();
        }

        /// <summary>
        /// Gets or set the instructions vairable
        /// </summary>
        public List<Instruction<T>> Instructions
        {
            get { return this._instructions; }
            set { this._instructions = value; }
        }

        /// <summary>
        /// gets or sets the fileName to save the location
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Add instruction to instructions list 
        /// </summary>
        /// <param name="actionType">the robot action type</param>
        /// <param name="action">the parameters for the action</param>
        public void AddInstruction(RobotActionType actionType, T action)
        {
            var instruction = new Instruction<T>();
            instruction.ActionType = actionType;
            instruction.Parameters = action;
            Instructions.Add(instruction);
        }

        /// <summary>
        /// Save the instructions to a file 
        /// </summary>
        /// <param name="fileName">the fileName</param>
        /// <returns>nothing</returns>
        public void SaveAllInstructionsToFile()
        {
            var jsonString = JsonConvert.SerializeObject(this.Instructions);
            // File.WriteAllText(this.FileName, jsonString);

            if (File.Exists(this.FileName))
                File.Delete(this.FileName);

            using (var fw = new StreamWriter(this.FileName, true))
            {
                fw.Write(jsonString.ToString());
                fw.Close();
            }
        }

        /// <summary>
        /// disposes unused resources of this class
        /// </summary>
        /// <param name="disposing">the dipsosing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (this.Instructions != null)
                        this.Instructions = null;

                    if (!string.IsNullOrEmpty(this.FileName))
                        this.FileName = string.Empty;
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// disposes unused resources of this class
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
