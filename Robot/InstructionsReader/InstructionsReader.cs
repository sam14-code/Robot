using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Robot.Converters;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Robot.InstructionsReader
{
    /// <summary>
    /// The Instruction Reader class
    /// </summary>
    /// <typeparam name="T">the generic type</typeparam>
    public class InstructionsReader<T> : IInstructionsReader<T> where T : RobotAction
    {
        /// <summary>
        /// variable to store instructions
        /// </summary>
        private List<Instruction<T>> _instructions; 
        /// <summary>
        /// the disposed value
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        /// reads next instruction from memory
        /// </summary>
        /// <returns></returns>
        public Instruction<T> ReadandExecuteNextInstruction()
        {
            return null;
        }

        /// <summary>
        /// Gets or set the Instructions variable
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
        /// Read all instructions from file
        /// </summary>
        /// <param name="fileName">the fileName</param>
        /// <returns></returns>
        public void ReadInstructionsFromFile()
        {
            using (var sr = new StreamReader(this.FileName))
            {
                var json = sr.ReadToEnd();
                this.Instructions = JsonConvert.DeserializeObject<List<Instruction<T>>>(json, new KnownTypeConverter());                
                sr.Close();
            }
        }

        /// <summary>
        /// Disposes unused resources of this class
        /// </summary>
        /// <param name="disposing"></param>
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
        /// Disposes unsused resources of this class
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
