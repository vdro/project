using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOne.Controllers;
using ProjectOne.Models;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ProjectOne.Interfaces;
using System.Threading.Tasks;


namespace ProjectOne.SpecFlow
{
    [Binding]
    public sealed class StepDefinition1
    {
        private readonly ScenarioContext context;
        private AzureController azureController;
        private bool azureResult;  

        public StepDefinition1(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"AzureController initiated with dependencies")]
        public void GivenAzureControllerInitiatedWithDependencies()
        {
            var azureServiceMock = new Mock<IAzureService>();
            azureServiceMock.Setup(x => x.TriggerLogicApp(It.IsAny<AzureModel>())).Returns(Task.FromResult(true));

            azureController = new AzureController(azureServiceMock.Object);
        }

        [When(@"calling the TriggerLogicApp with below AzureModel")]
        public async void WhenCallingTheTriggerLogicAppWithBelowAzureModel(Table table)
        {
            var row = table.Rows[0];
            AzureModel azureModel = new AzureModel
            {
                FirstName = row["FirstName"],
                LastName = row["LastName"],
                Email = row["Email"],
                PhoneNumber = row["PhoneNumber"]
            };

            azureResult = await azureController.TriggerLogicApp(azureModel);
        }

        [Then(@"something happens")]
        public void ThenSomethingHappens()
        {
            Assert.IsTrue(azureResult);
        }

    }
}
