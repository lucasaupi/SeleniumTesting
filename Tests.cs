namespace TestsProject
{
    [TestFixture]
    public class Tests : TestBase
    {
        private readonly string user = "";
        private readonly string password = "";
        private readonly string ort = "https://aulavirtual.instituto.ort.edu.ar/";
        private readonly string w3 = "https://www.w3schools.com/jsref/tryit.asp?filename=tryjsref_confirm";

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