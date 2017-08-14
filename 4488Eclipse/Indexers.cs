using WPILib;

namespace _4488Eclipse
{
    class Indexers
    {
        private Talon Left, Right;
        private DigitalInput ShooterBallSensor;

        public Indexers()
        {
            Left = new Talon(Config.IndexMotorL);
            Right = new Talon(Config.IndexMotorR);
            ShooterBallSensor = new DigitalInput(Config.IndexerBeamBreak);
        }

        public void insert(bool button)
        {
            if(button == true)
            {
                Left.Set(-0.25);
                Right.Set(0.25);
            }

            if(ShooterBallSensor.Get() == false)
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
            if(button == true)
            {
                Left.Set(0.0);
                Right.Set(0.0);
            }
        }
    }
}