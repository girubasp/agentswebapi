using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Agents.Data.Tests
{
    [TestClass]
    public class AgentsServiceTests
    {

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void agents_list_calls_agents_service()
        {
            //Arrange
            var controller = new AgentsDB();
            //Act
            controller.Get();
        }
    }
}