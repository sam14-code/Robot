using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Robot.Models
{
    /// <summary>
    /// The Robot Action class 
    /// </summary>
    [KnownType(typeof(Move))]
    [KnownType(typeof(Rotate))]
    [KnownType(typeof(Beep))]
    public class RobotAction{
    }

    /// <summary>
    /// The enum of Robot Action type
    /// </summary>
    public enum RobotActionType
    {
        Move = 0,
        Rotate = 1, 
        Beep = 2
    }
}
