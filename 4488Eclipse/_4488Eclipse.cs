using System;
using WPILib;
using WPILib.SmartDashboard;

namespace _4488Eclipse
{
    /// <summary>
    /// The VM is configured to automatically run this class, and to call the
    /// functions corresponding to each mode, as described in the IterativeRobot
    /// documentation. 
    /// </summary>
    public class _4488Eclipse : IterativeRobot
    {
        const string defaultAuto = "Default";
        const string customAuto = "My Auto";
        public bool after = false;
        public bool afterafter = false;
        string autoSelected;
        SendableChooser chooser;
        long startTime;
        Drive driver;
        Control controller;
        Indexers indexers;

        public override void RobotInit()
        {
            driver = new Drive();
            controller = new Control();
            indexers = new Indexers();
            chooser = new SendableChooser();
            chooser.AddDefault("Default Auto", defaultAuto);
            chooser.AddObject("My Auto", customAuto);
            SmartDashboard.PutData("Chooser", chooser);
        }

        // This autonomous (along with the sendable chooser above) shows how to select between
        // different autonomous modes using the dashboard. The senable chooser code works with
        // the Java SmartDashboard. If you prefer the LabVIEW Dashboard, remove all the chooser
        // code an uncomment the GetString code to get the uto name from the text box below
        // the gyro.
        //You can add additional auto modes by adding additional comparisons to the switch
        // structure below with additional strings. If using the SendableChooser
        // be sure to add them to the chooser code above as well.
        public override void AutonomousInit()
        {
            autoSelected = (string)chooser.GetSelected();
            //autoSelected = SmartDashboard.GetString("Auto Selector", defaultAuto);
            Console.WriteLine("Auto selected: " + autoSelected);

            startTime = Environment.TickCount;
            driver.LeftM.Set(1.0);
            driver.RightM.Set(1.0);
        }

        /*
         * I wouldn't recommend running an auto like this.
         * This is just testing with the after bools.
         * May also at some point remove autoselected switch statement.
        */
        public override void AutonomousPeriodic()
        {
            switch (autoSelected)
            {
                case customAuto:
                    driver.LeftM.Set(1.0);
                    break;
                case defaultAuto:
                default:
                    if((Environment.TickCount - startTime) > 5000 && !after && !afterafter)
                    {
                        driver.LeftM.Set(0.0);
                        driver.RightM.Set(0.0);
                        startTime = Environment.TickCount;
                        after = true;
                    }

                    if((Environment.TickCount - startTime) > 2000 && after && !after)
                    {
                        driver.LeftM.Set(0.4);
                        driver.RightM.Set(0.4);
                    }

                    if((Environment.TickCount - startTime) > 2000 && after && !afterafter)
                    {
                        driver.LeftM.Set(0.0);
                        driver.RightM.Set(0.0);
                        startTime = Environment.TickCount;
                        afterafter = true;
                    }
                    break;
            }
        }

        public override void TeleopPeriodic()
        {
            driver.driver(controller.getDrivePowerL(), controller.getDrivePowerR());
            driver.turnL(controller.getLTurnButton());
            driver.turnR(controller.getRTurnButton());
            indexers.insert(controller.getInsertButton());
            indexers.eject(controller.getEjectButton());
            indexers.stop(controller.getStopButton());
        }

        public override void TestPeriodic()
        {
            //I don't even know...
            Console.WriteLine("Test Initialized");
        }
    }
}
