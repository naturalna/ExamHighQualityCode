using Calendar_System;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystemTests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Parse_RegularParseTrueCommandName()
        {
            string commandParams = "AddEvent 2011-11-11T11:11:22 | party Viki | home";
            Command newCommand = Command.Parse(commandParams);
            Assert.IsTrue(newCommand.CommandName == "AddEvent");
        }

        [TestMethod]
        public void Parse_RegularParseTrueParameters()
        {
            string commandParams = "AddEvent 2011-11-11T11:11:22 | party Viki | home";
            Command newCommand = Command.Parse(commandParams);
            Assert.IsTrue(newCommand.Paramms[0] == "2011-11-11T11:11:22");
            Assert.IsTrue(newCommand.Paramms[1] == "party Viki");
            Assert.IsTrue(newCommand.Paramms[2] == "home");
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void Parse_InvalidCommandWithoutEmptySpaces()
        {
            string commandParams = "AddEven2011-11-11T11:11:22|partyViki|home";
            Command newCommand = Command.Parse(commandParams);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void Parse_InvalidCommandWithoutEmptySpace()
        {
            string commandParams = "AddEven2011-11-11T11:11:22| partyViki | home";
            Command newCommand = Command.Parse(commandParams);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void Parse_InvalidCommandmissingWhiteSpaceBetweenCommandAndFirstArgument()
        {
            string commandParams = "AddEven2011-11-11T11:11:22 | partyViki | home";
            Command newCommand = Command.Parse(commandParams);
        }
    }
}
