using Robotica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class AIRobot : IRobot
    {
        public AIRobot()
        {
        }

        public void Beep()
        {
            // Added for testing purpose
            Console.WriteLine("Robot Beep");
        }

        public void Move(int distance, double speed)
        {
            // Added for testing purpose
            Console.WriteLine($"Robot moved   distance : {distance} speed : {speed}");
        }

        public void Rotate(float angle)
        {
            // Added for testing purpose
            Console.WriteLine($"Robot rotated   angle: {angle}");
        }
    }
}
