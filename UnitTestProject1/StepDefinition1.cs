using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOne.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjectOne.UnitTestProject1
{
    [Binding]
    public sealed class StepDefinition1
    {
        private readonly ScenarioContext context;
        private AzureController azureController;

        public StepDefinition1(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"AzureController initiated with dependencies")]
        public void GivenAzureControllerInitiatedWithDependencies()
        {
            azureController = new AzureController();
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

            await azureController.TriggerLogicApp(azureModel);
        }

        [Then(@"something happens")]
        public void ThenSomethingHappens()
        {
            //jakis assert albo co tam testujemy
            //np jakby troche przerobic controler zeby client http byl wrzucany przez IOC to mozna go zmockowac
        }

    }
}
