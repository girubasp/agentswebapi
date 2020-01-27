using Agents.Data;
using Agents.Service;
using agentsapi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace agentsapi.Tests
{
    [TestClass]
    public class AgentsListControllerTests
    {
        private Mock<IAgentsService> _agentsService;

        [TestInitialize]
        public void Setup()
        {
            _agentsService = new Mock<IAgentsService>();
        }

        [TestMethod]
        public void agents_list_calls_agents_service()
        {
            //Arrange
            var controller = new AgentsListController(_agentsService.Object);
            //Act
            controller.Get();
            //Assert
            _agentsService.Verify(a=>a.Get(),Times.Once);
        }
    }
}
