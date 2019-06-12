using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOne.Controllers;

namespace UserForm.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new AzureController();
            var result = controller.TriggerLogicApp(new AzureModel
            {
                Email = "test@123.pl",
                FirstName = "Ziom",
                LastName = "LastName",
                PhoneNumber = "5554555"
            }).GetAwaiter().GetResult();

            Assert.IsTrue(result, "Something went wrong with triggering Azure Logic App...");
        }
    }
}
