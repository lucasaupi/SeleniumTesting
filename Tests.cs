namespace TestsProject
{
    [TestFixture]
    public class Tests : TestBase
    {
        private readonly string user = Environment.GetEnvironmentVariable("ORT_USER") ?? "ORT_USER";
        private readonly string password = Environment.GetEnvironmentVariable("ORT_PASSWORD") ?? "ORT_PASSWORD";
        private readonly string ort = Environment.GetEnvironmentVariable("ORT_URL") ?? "ort_url";
        private readonly string w3 = Environment.GetEnvironmentVariable("ORT_URL") ?? "W3_URL";

        [Test]
        public void TestOrt()
        {

            Actions.GoToPage(ort);
            LogIn(user, password);

            locators.ProgramacionDos.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.EvaluacionesGenerales);
            locators.EvaluacionesGenerales.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.SimulacroParcial);
            //Actions.ViewTheElement(selectors.SegundoFinal);
            locators.SegundoFinal.WaitUntilClickeable().Click();
            Actions.Sleep();
        }

        [Test]
        public void TestW3()
        {

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
            string text = Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id");
            Assert.IsTrue(Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id").Equals("username"));
            locators.UserName.SendKeys(user);
            locators.Password.SendKeys(password);
            locators.LogInButton.WaitUntilClickeable().Click();
        }
    }
}