using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Robot.InstructionsReader;
using Robot.Models;
using Robot.RobotInstructionsWriter;
using Robotica;
using Robus;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Robot.UnitTests
{
    /// <summary>
    /// RobusApi Unit Test class
    /// </summary>
    [TestClass]
    public class RobusApiTests
    {
        /// <summary>
        /// The api
        /// </summary>
        private readonly RobusApi _api;

        /// <summary>
        /// Mock of instructions writer
        /// </summary>
        private readonly Mock<IInstructionsWriter<RobotAction>> _mockWriter = new Mock<IInstructionsWriter<RobotAction>>();
        
        /// <summary>
        /// Mock of instructions reader
        /// </summary>
        private readonly Mock<IInstructionsReader<RobotAction>> _mockReader = new Mock<IInstructionsReader<RobotAction>>();

        /// <summary>
        /// Mock of robot 
        /// </summary>
        private readonly Mock<IRobot> _mockRobot = new Mock<IRobot>();

        /// <summary>
        /// creates a new instance of <see cref="RobusApiTests"/> Tests class.
        /// </summary>
        public RobusApiTests()
        {
            this._api = new RobusApi(this._mockWriter.Object, this._mockReader.Object);
        }

        /// <summary>
        /// Tests Draw square method executes and saves all the instructions into a file successfully
        /// </summary>
        [TestMethod]
        public void DrawSquare_Should_successfully_save_instructions_to_file()
        {
            // arrange 
            this._mockRobot.Setup(x => x.Move(It.IsAny<int>(), It.IsAny<double>())).Verifiable();
            this._mockRobot.Setup(x => x.Rotate(It.IsAny<float>())).Verifiable();
            this._mockRobot.Setup(x => x.Beep()).Verifiable();

            this._mockWriter.Setup(x => x.AddInstruction(It.IsAny<RobotActionType>(), It.IsAny<RobotAction>())).Verifiable();
            this._mockWriter.Setup(x => x.SaveAllInstructionsToFile()).Verifiable();

            //act 
            this._api.DrawSquare<IRobot>(this._mockRobot.Object);

            //assert 
            
            this._mockRobot.Verify(x => x.Move(It.IsAny<int>(), It.IsAny<double>()), Times.Exactly(4));
            this._mockRobot.Verify(x => x.Rotate(It.IsAny<float>()), Times.Exactly(3));

            this._mockWriter.Verify(x => x.AddInstruction(It.IsAny<RobotActionType>(), It.IsAny<RobotAction>()),Times.Exactly(7));
            this._mockWriter.Verify(x => x.SaveAllInstructionsToFile(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Tests Draw square method executes and saves all the instructions into a file successfully
        /// </summary>
        [TestMethod]
        public void Replay_Should_Read_Execute_Instructions_Correctly()
        {
            // arrange 
            this._mockRobot.Setup(x => x.Move(It.IsAny<int>(), It.IsAny<double>())).Verifiable();
            this._mockRobot.Setup(x => x.Rotate(It.IsAny<float>())).Verifiable();
            this._mockRobot.Setup(x => x.Beep()).Verifiable();

            this._mockReader.Setup(x => x.ReadInstructionsFromFile()).Verifiable();
            this._mockReader.SetupGet(x => x.Instructions).Returns(this.CreateInstructionsList());

            //act 
            this._api.Replay<IRobot>(this._mockRobot.Object);

            //assert 
            this._mockRobot.Verify(x => x.Move(It.IsAny<int>(), It.IsAny<double>()), Times.Exactly(2));
            this._mockRobot.Verify(x => x.Rotate(It.IsAny<float>()), Times.Exactly(2));

            this._mockReader.Verify(x => x.ReadInstructionsFromFile(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Creates and return a list of instructions
        /// </summary>
        /// <returns>the list of instructions</returns>
        private List<Instruction<RobotAction>> CreateInstructionsList()
        {
            List<Instruction<RobotAction>> instructions = new List<Instruction<RobotAction>>();
            
            instructions.Add(this.CreateInstruction(RobotActionType.Move, new Move(10, 1)));
            instructions.Add(this.CreateInstruction(RobotActionType.Rotate, new Rotate(90)));

            instructions.Add(this.CreateInstruction(RobotActionType.Move, new Move(10, 1)));
            instructions.Add(this.CreateInstruction(RobotActionType.Rotate, new Rotate(90)));

            return instructions;
        }

        /// <summary>
        /// Create a instruction
        /// </summary>
        /// <param name="actionType">the actionType</param>
        /// <param name="action">the action</param>
        /// <returns>the created instruction</returns>
        private Instruction<RobotAction> CreateInstruction(RobotActionType actionType, RobotAction action)
        {
            var instruction = new Instruction<RobotAction>();
            instruction.ActionType = actionType;
            instruction.Parameters = action;

            return instruction;
        }
    }
}
