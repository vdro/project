using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOne.Services;
using Moq;
using ProjectOne.Models;

namespace UserForm.Tests
{
    [TestClass]
    public class AzureServiceIntegrationTests
    {
        [TestMethod]
        public void WhenCallToAzureIsSuccesful_ThenAzureServiceReturnsTrue()
        {
            var controller = new AzureService();
            var result = controller.TriggerLogicApp(new AzureModel
            {
                Email = "test@123.pl",
                FirstName = "Ziom",
                LastName = "LastName",
                PhoneNumber = "5554555"
            }).GetAwaiter().GetResult();

            Assert.IsTrue(result);
        }
    }
}
