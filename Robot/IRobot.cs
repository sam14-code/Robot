namespace Robotica
{
    /// <summary>
    /// Represents control over robot.[External class] - Avoid modifications
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Moves the robot.
        /// </summary>
        /// <param name="distance">The distance to move the robot.</param>
        /// <param name="speed">The speed to move at.</param>
        void Move(int distance, double speed);

        /// <summary>
        /// Rotates the robot.
        /// </summary>
        /// <param name="angle">The angle to rotate at.</param>
        void Rotate(float angle);

        ///<summary>
        /// Instructs the robot to produce an audible beep.
        ///</summary>
        void Beep();
    }
}