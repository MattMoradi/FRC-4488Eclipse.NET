using CSharpRoboticsLib.WPIExtensions;
using WPILib;

namespace _4488Eclipse
{
    class Drive
    {
        public CANTalon LeftM, Left1, Left2, RightM, Right1, Right2;
        private SpeedControllerGroup LeftFollowers;
        private SpeedControllerGroup RightFollowers;

        public Drive()
        {
            LeftM = new CANTalon(Config.DriveLeftM);
            Left1 = new CANTalon(Config.DriveLeft1);
            Left1.MotorControlMode = WPILib.Interfaces.ControlMode.Follower;
            Left1.Set(Config.DriveLeft1);
            Left2 = new CANTalon(Config.DriveLeft2);
            Left2.MotorControlMode = WPILib.Interfaces.ControlMode.Follower;
            Left2.Set(Config.DriveLeft2);
            LeftFollowers = new SpeedControllerGroup(Left1, Left2);
            RightM = new CANTalon(Config.DriveRightM);
            Right1 = new CANTalon(Config.DriveRight1);
            Right1.MotorControlMode = WPILib.Interfaces.ControlMode.Follower;
            Right1.Set(Config.DriveRight1);
            Right2 = new CANTalon(Config.DriveRight2);
            Right2.MotorControlMode = WPILib.Interfaces.ControlMode.Follower;
            Right2.Set(Config.DriveRight2);
            RightFollowers = new SpeedControllerGroup(Right1, Right2);
        }//end Drive

            public void driver(double left, double right)
            {
                LeftM.Set(left);
                RightM.Set(-right);
            }

            public void turnL(bool button)
            {
                if (button == true)
                {
                    LeftM.Set(0.5);
                    RightM.Set(0.0);
                }
            }

            public void turnR(bool button)
            {
                if(button == true)
                {
                    LeftM.Set(0.0);
                    RightM.Set(-0.5);
                }
            }
        }//end class
    }//end namespace
