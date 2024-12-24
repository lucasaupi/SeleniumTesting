using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    [TestFixture]
    public class Tests2 : TestBase
    {
        private readonly string user = "";
        private readonly string password = "";
        private readonly string ort = "https://aulavirtual.instituto.ort.edu.ar/";

        [Test]
        public void TestOrt()
        {

            //Actions.GetDriver().Navigate().GoToUrl(ort);
            //LogIn(user, password);

            //if (locators.OpenPanel.IsElementVisible()) locators.OpenPanel.WaitUntilClickeable().Click();
            //locators.ProgramacionDos.WaitUntilClickeable().Click();
            //Actions.ViewTheElement(locators.EvaluacionesGenerales);
            //locators.EvaluacionesGenerales.WaitUntilClickeable().Click();
            //Actions.ViewTheElement(locators.SimulacroParcial);
            ////Actions.ViewTheElement(selectors.SegundoFinal);
            //locators.SegundoFinal.WaitUntilClickeable().Click();
            //Actions.Sleep();
        }
        private void LogIn(string user, string password)
        {
            //Actions.WaitUntilClickeable(locators.AccederDos).Click();
            //string text = Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id");
            //Assert.IsTrue(Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id").Equals("username"));
            //Actions.WaitUntilClickeable(locators.UserName).SendKeys(user);
            //Actions.WaitUntilClickeable(locators.Password).SendKeys(password);
            //locators.LogInButton.WaitUntilClickeable().Click();
        }
    }
}
