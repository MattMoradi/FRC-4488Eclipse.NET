using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;

namespace MatRobot
{
    public class IndexMotors
    {
        private Talon Left, Right;
        private DigitalInput m_shooterBallSensor;

        public IndexMotors()
        {
            Left = new Talon(RobotMap.IndexMotorL);
            Right = new Talon(RobotMap.IndexMotorR);
            m_shooterBallSensor = new DigitalInput(RobotMap.IndexerBeamBreak);
        }

        public void insert(bool button)
        {
            if (button == true)
            {
                Left.Set(-0.25);
                Right.Set(0.25);
            }
            if (m_shooterBallSensor.Get() == false)
            {
                stop(true);
            }
        }
        public void eject(bool button)
        {
            if (button == true)
            {
                Left.Set(1.0);
                Right.Set(-1.0);
            }
        }
        public void stop(bool button)
        {
            if (button == true)
            {
                Left.Set(0.0);
                Right.Set(0.0);
            }
        }
    }
}
