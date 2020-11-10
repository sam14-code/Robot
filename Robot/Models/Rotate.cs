using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Models
{
    /// <summary>
    /// The Rotate Class 
    /// </summary>
    public class Rotate  : RobotAction   {

        /// <summary>
        /// Creates a new instance of <see cref="Rotate"/> class
        /// </summary>
        public Rotate() : this(0){
        }

        /// <summary>
        /// Creates and new instance of <see cref="Rotate"/> class
        /// </summary>
        /// <param name="angle">the angle</param>
        public Rotate(float angle){
            this.Angle = angle;
        }

        /// <summary>
        /// gets or sets the Angle
        /// </summary>
        [JsonProperty("angle")]
        public float Angle { get; set; }
    }
}
