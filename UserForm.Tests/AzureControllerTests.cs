using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOne.Controllers;
using Moq;
using ProjectOne.Interfaces;
using ProjectOne.Models;
using System.Threading.Tasks;

namespace UserForm.Tests
{
    [TestClass]
    public class AzureControllerTests
    {


        [TestMethod]
        public void WhenCallToAzureIsSuccesful_ThenAzureControllerReturnsTrue()
        {
            var azureServiceMock = new Mock<IAzureService>();
            azureServiceMock.Setup(x => x.TriggerLogicApp(It.IsAny<AzureModel>())).Returns(Task.FromResult(true));

            var controller = new AzureController(azureServiceMock.Object);
            var result = controller.TriggerLogicApp(new AzureModel
            {
                Email = "test@123.pl",
                FirstName = "Ziom",
                LastName = "LastName",
                PhoneNumber = "5554555"
            }).GetAwaiter().GetResult();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenCallToAzureIsNotSuccesful_ThenAzureControllerReturnsFalse()
        {
            var azureServiceMock = new Mock<IAzureService>();
            azureServiceMock.Setup(x => x.TriggerLogicApp(It.IsAny<AzureModel>())).Returns(Task.FromResult(false));

            var controller = new AzureController(azureServiceMock.Object);
            var result = controller.TriggerLogicApp(new AzureModel
            {
                Email = "test@123.pl",
                FirstName = "Ziom",
                LastName = "LastName",
                PhoneNumber = "5554555"
            }).GetAwaiter().GetResult();

            Assert.IsFalse(result);
        }
    }
}
