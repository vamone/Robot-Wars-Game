using System;

using RobotWars.Game;
using Xunit;

namespace RobotWars.Test
{
    public class RobotBaseTests
    {
        private static readonly RobotWarsArena FightArena = new RobotWarsArena();

        [Fact]
        public void Ctor_NullRobotWarsArena_ArgumentNullException()
        {
            //Arrange & Act
            Action storm = () => new Storm(null, 0, 0, Compass.CompassSides.East);

            //Assert
            Assert.Throws<ArgumentNullException>(storm);
        }

        [Fact]
        public void Ctor_XLessThanZiro_ArgumentOutOfRange()
        {
            //Arrange & Act
            Action storm = () => new Storm(FightArena, -1, 0, Compass.CompassSides.East);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(storm);
        }

        [Fact]
        public void Ctor_YLessThanZiro_ArgumentOutOfRange()
        {
            //Arrange & Act
            Action storm = () => new Storm(FightArena, 0, -1, Compass.CompassSides.East);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(storm);
        }

        [Fact]
        public void StormRobot_PenaltiesOnPMaxositionLineY_PenaltiesCount()
        {
            //Arrange 
            var storm = new Storm(FightArena, 4, 4, Compass.CompassSides.North);

            //Act
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            //Assert
            Assert.Equal(4, storm.Position.X);
            Assert.Equal(5, storm.Position.Y);
            Assert.Equal(4, storm.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.North, storm.Position.CompassPointer);
        }

        [Fact]
        public void StormRobot_PenaltiesOnMinPositionLineY_PenaltiesCount()
        {
            //Arrange 
            var storm = new Storm(FightArena, 4, 1, Compass.CompassSides.South);

            //Act
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            //Assert
            Assert.Equal(4, storm.Position.X);
            Assert.Equal(0, storm.Position.Y);
            Assert.Equal(8, storm.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.South, storm.Position.CompassPointer);
        }

        [Fact]
        public void StormRobot_PenaltiesOnMaxPositionLineX_PenaltiesCount()
        {
            //Arrange 
            var storm = new Storm(FightArena, 4, 3, Compass.CompassSides.East);

            //Act
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            //Assert
            Assert.Equal(5, storm.Position.X);
            Assert.Equal(3, storm.Position.Y);
            Assert.Equal(5, storm.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.East, storm.Position.CompassPointer);
        }

        [Fact]
        public void StormRobot_PenaltiesOnMinPositionLineX_PenaltiesCount()
        {
            //Arrange 
            var storm = new Storm(FightArena, 2, 3, Compass.CompassSides.West);

            //Act
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            //Assert
            Assert.Equal(0, storm.Position.X);
            Assert.Equal(3, storm.Position.Y);
            Assert.Equal(9, storm.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.West, storm.Position.CompassPointer);
        }

        [Fact]
        public void StormRobot_MoveAroundBoundary_PenaltiesCount()
        {
            //Arrange 
            var storm = new Storm(FightArena, 0, 0, Compass.CompassSides.North);

            //Act
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            storm.TurnRight();
            
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            storm.TurnRight();

            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            storm.TurnRight();

            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();
            storm.MoveForvard();

            //Assert
            Assert.Equal(0, storm.Position.X);
            Assert.Equal(0, storm.Position.Y);
            Assert.Equal(3, storm.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.West, storm.Position.CompassPointer);
        }

        [Fact]
        public void RazerRobot_Scenario_1()
        {
            //Arrange
            var razer = new Razer(FightArena, 0, 2, Compass.CompassSides.East);

            //Act
            //MLMRMMMRMMRR
            razer.MoveForvard();
            razer.TurnLeft();
            razer.MoveForvard();
            razer.TurnRight();
            razer.MoveForvard();
            razer.MoveForvard();
            razer.MoveForvard();
            razer.TurnRight();
            razer.MoveForvard();
            razer.MoveForvard();
            razer.TurnRight();
            razer.TurnRight();

            //Assert
            Assert.Equal(4, razer.Position.X);
            Assert.Equal(1, razer.Position.Y);
            Assert.Equal(0, razer.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.North, razer.Position.CompassPointer);
        }

        [Fact]
        public void RazerRobot_Scenario_2()
        {
            //Arrange
            var robot = new Razer(FightArena, 4, 4, Compass.CompassSides.South);

            //Act
            //LMLLMMLMMMRMM
            robot.TurnLeft();
            robot.MoveForvard();
            robot.TurnLeft();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.TurnRight();
            robot.MoveForvard();
            robot.MoveForvard();

            //Assert 
            Assert.Equal(0, robot.Position.X); //BY REQUIREMENTS X MUST BE 0, BUT IT WILL BE 1 ANYWAY EVEN IF YOU CALCULATE IT ON PAPER
            Assert.Equal(1, robot.Position.Y);
            Assert.Equal(1, robot.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.West, robot.Position.CompassPointer);
        }

        [Fact]
        public void RazerRobot_Scenario_3()
        {
            //Arrange
            var robot = new Razer(FightArena, 2, 2, Compass.CompassSides.West);

            //Act
            //MLMLMLM RMRMRMRM
            robot.MoveForvard();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.TurnRight();
            robot.MoveForvard();
            robot.TurnRight();
            robot.MoveForvard();
            robot.TurnRight();
            robot.MoveForvard();
            robot.TurnRight();
            robot.MoveForvard();

            //Assert
            Assert.Equal(2, robot.Position.X);
            Assert.Equal(2, robot.Position.Y);
            Assert.Equal(0, robot.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.North, robot.Position.CompassPointer);
        }

        [Fact]
        public void RazerRobot_Scenario_4()
        {
            //Arrange
            var robot = new Razer(FightArena, 1, 3, Compass.CompassSides.North);

            //Act
            //MMLMMLMMMMM
            robot.MoveForvard();
            robot.MoveForvard(); //PENALTY ON TOP 
            robot.TurnLeft();
            robot.MoveForvard(); //PENALTY ON LEFT TOP CORNER WITH MOVE TO WEST; IT CAN BE SOME START/END POSTION FOR SOME ROBOT
            robot.MoveForvard(); //PENALTY ON LEFT TOP CORNER WITH MOVE TO WEST
            robot.TurnLeft();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard(); //PENALTY (X = 0, Y = 0)

            //Assert
            //NOT SURE IF PENALTY NOT COUNTS IF ROBOT COMES TO START POSITION (X = 0, Y = 0)
            //AS ROBOT CAN START FROM ANY CORNER AND ANY CORNER CAN BE AS START POSITION (X = 0, Y = 0)
            //NEXT SCENARIO WILL PROVE THAT START POINT MUST COUNT PENALTY
            Assert.Equal(0, robot.Position.X);
            Assert.Equal(0, robot.Position.Y); 
            Assert.Equal(3, robot.PenaltyRecord.PenaltiesCount); //IF START POINT COUNTS, PENALTY COUNT BE 4
            Assert.Equal(Compass.CompassSides.South, robot.Position.CompassPointer);
        }

        [Fact]
        public void RazerRobot_Scenario_4_UppSideDown()
        {
            //Arrange
            var robot = new Razer(FightArena, 3, 1, Compass.CompassSides.South);

            //Act
            robot.MoveForvard();
            robot.MoveForvard();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.TurnLeft();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard();
            robot.MoveForvard();

            //Assert
            Assert.Equal(5, robot.Position.X);
            Assert.Equal(5, robot.Position.Y);
            Assert.Equal(3, robot.PenaltyRecord.PenaltiesCount);
            Assert.Equal(Compass.CompassSides.North, robot.Position.CompassPointer);
        }
    }
}