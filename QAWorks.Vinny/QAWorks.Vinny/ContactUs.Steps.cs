using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace QAWorks.Vinny
{
    [Binding]
    public sealed class ContactUs : ContactUsPage
    {
        [Given(@"I am on the QAWoks Staging Contact Us page")]
        public void GivenIAmOnTheQAWoksStagingContactUsPage()
        {
           NavigateToContactUsPage();
        }

        [Then(@"I should be able to contact QAWorks with the following information")]
        public void ThenIShouldBeAbleToContactQAWorksWithTheFollowingInformation(Table table)
        {
            var form = table.CreateInstance<ContactUsForm>();
            NameBox.SendKeys(form.Name);
            EmailBox.SendKeys(form.Email);
            MessageBox.SendKeys(form.Message);
            SendButton.SendKeys(Keys.Return);
            Assert.That(!NameValidation.Displayed, "Form not submitted due to Name validation");
            Assert.That(!EmailValidation.Displayed, "Form not submitted due to invalid Email");
            Assert.That(!EmailBoxValidation.Displayed, "Form not submitted due to Email validation");
            Assert.That(!MessageValidation.Displayed, "Form not submitted due to Messsage validation");
        }
        
        [When(@"I submit the form with ""(.*)"", ""(.*)"", ""(.*)"" with one of the fields left blank or with an invalid email")]
        public void WhenISubmitTheFormWithWithOneOfTheFieldsLeftBlankOrWithAnInvalidEmail(string name, string email, string message)
        {
            //Hard to pass an empty string in Scenario Outline examples hence the below line
            if (name == "\"\"") name = string.Empty; if (email == "\"\"") email = string.Empty; if (message == "\"\"") message = string.Empty;

            NameBox.SendKeys(name);
            EmailBox.SendKeys(email);
            MessageBox.SendKeys(message);
            SendButton.SendKeys(Keys.Return);
        }


        [Then(@"I should see the appropriate ""(.*)"" validation")]
        public void ThenIShouldSeeTheAppropriateYourNameIsRequiredValidation(string validation)
        {
            Assert.AreEqual(ValidationDisplayed(), validation);
        }


        private static string ValidationDisplayed()
        {
            var validation = ValidationMessages().First(x => x.Displayed);
            return validation.Text;
        }


    
    }

}
