using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Models
{
    /// <summary>
    /// The Move Class
    /// </summary>
    public class Move : RobotAction
    {
        /// <summary>
        /// creates a new instance of <see cref="Move"/> class
        /// </summary>
        public Move() : this (0,0){
        }

        /// <summary>
        /// creates a new instance of <see cref="Move"/> class
        /// </summary>
        /// <param name="distance">the distance</param>
        /// <param name="point">the point</param>
        public Move(int distance, double point)
        {
            this.Distance = distance;
            this.Point = point;
        }

        /// <summary>
        /// Gets or sets the Distance
        /// </summary>
        [JsonProperty("distance")]
        public int Distance { get; set; }
        
        /// <summary>
        /// Gets or sets the Point
        /// </summary>
        [JsonProperty("point")]
        public double Point { get; set; }
    }
}
