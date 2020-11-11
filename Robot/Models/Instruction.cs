using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Models
{
    /// <summary>
    /// The Instruction class
    /// </summary>
    /// <typeparam name="T">the generic type</typeparam>
    public class Instruction<T> where T: RobotAction {

        /// <summary>
        /// creates a new instance of <see cref="instuction"/> class
        /// </summary>
        public Instruction(){
        }

        /// <summary>
        /// creates a new instance of <see cref="Instruction"/>
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="parameters"></param>
        public Instruction(RobotActionType actionType, T parameters)
        {
            this.ActionType = actionType;
            this.Parameters = parameters;
        }
        
        /// <summary>
        /// Gets or sets a function Type enum 
        /// </summary>
        [JsonProperty("ActionType")]
        public RobotActionType ActionType { get; set; }
        
        /// <summary>
        /// Gets or sets function parameters
        /// </summary>
        [JsonProperty("Parameters")]
        public T Parameters { get; set; }
    }
}
