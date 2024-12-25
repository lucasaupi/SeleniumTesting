using System.Diagnostics;

namespace TestsProject
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        public void TestOrt()
        {
            //Debug.WriteLine($"ort_user: {Environment.GetEnvironmentVariable("ORT_USERNAME")}");

            var user = Environment.GetEnvironmentVariable("ORT_USERNAME") ?? "ORT_USER";
            var password = Environment.GetEnvironmentVariable("ORT_PASSWORD") ?? "ORT_PASSWORD";
            var ort = Environment.GetEnvironmentVariable("ORT_URL") ?? "TEST";

            Actions.GoToPage(ort);
            LogIn(user, password);

            locators.ProgramacionDos.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.EvaluacionesGenerales);
            locators.EvaluacionesGenerales.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.SimulacroParcial);
            locators.SegundoFinal.WaitUntilClickeable().Click();
            Actions.Sleep();
        }

        [Test]
        public void TestW3()
        {

            var w3 = Environment.GetEnvironmentVariable("W3_URL") ?? "W3_URL";
            Actions.GoToPage(w3);
            //Actions.WaitUntilVisible(selectors.TextArea).Clear();
            Actions.SwitchToFrame(locators.IFrame);
            //Actions.SelectOptionByText(selectors.Options, "Option 2");
            Actions.WaitUntilClickeable(locators.ButtonInFrame).Click();
            Actions.WaitForAlertsAndConfirm();

        }

        private void LogIn(string user, string password)
        {
            Actions.WaitUntilClickeable(locators.AccederDos).Click();
            var text = Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id");
            Assert.IsTrue(Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id").Equals("username"));
            locators.UserName.SendKeys(user);
            locators.Password.SendKeys(password);
            locators.LogInButton.WaitUntilClickeable().Click();
        }
    }
}