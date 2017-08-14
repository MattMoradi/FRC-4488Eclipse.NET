using WPILib;

namespace _4488Eclipse
{
    class Control
    {
        Joystick controller;

        public void Controls()
        {
            controller = new Joystick(0);
        }

        public double getDrivePowerL()
        {
            return -controller.GetRawAxis(1);
        }

        public double getDrivePowerR()
        {
            return -controller.GetRawAxis(5);
        }

        public bool getLTurnButton()
        {
            return controller.GetRawButton(5);
        }

        public bool getRTurnButton()
        {
            return controller.GetRawButton(6);
        }

        public bool getEjectButton()
        {
            return controller.GetRawButton(4);
        }

        public bool getInsertButton()
        {
            return controller.GetRawButton(1);
        }

        public bool getStopButton()
        {
            return controller.GetRawButton(2);
        }
    }
}
