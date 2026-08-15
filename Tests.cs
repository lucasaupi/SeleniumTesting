using OpenQA.Selenium;
using System.Diagnostics;

namespace TestsProject
{
    [TestFixture]
    public class Tests : TestBase
    {
        [TestCase("ELE")]
        [TestCase("P3")]
        [TestCase("TP3")]
        [TestCase("CalidadSoftware")]
        public void AsistORT(string materia)
        {
            var user = Environment.GetEnvironmentVariable("ORT_USERNAME") ?? "ORT_USER";
            var password = Environment.GetEnvironmentVariable("ORT_PASSWORD") ?? "ORT_PASSWORD";
            var ort = Environment.GetEnvironmentVariable("ORT_URL") ?? "TEST";

            Actions.GoToPage(ort);
            LogIn(user, password);
            Actions.ViewTheElement(locators.PanelDerecho);
            locators.PanelDerecho.WaitUntilClickable().Click();
            SeleccionarMateria(materia);

            //Actions.ViewTheElement(locators.PanelIzquierdo);
            //locators.PanelIzquierdo.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.Asistencia);
            locators.Asistencia.WaitUntilClickable().Click();
            Actions.ViewTheElement(locators.EnviarAsistencia);
            locators.EnviarAsistencia.WaitUntilClickable().Click();
            Actions.ViewTheElement(locators.Present);
            locators.Present.WaitUntilClickable().Click();
            Actions.ViewTheElement(locators.GuardarAsistencia);
            locators.GuardarAsistencia.WaitUntilClickable().Click();
            Actions.Sleep(2);
        }

        private void SeleccionarMateria(string materiaKey)
        {
            By materia = materiaKey switch
            {
                "ELE" => locators.Electronica,
                "P3" => locators.Programacion3,
                "TP3" => locators.TallerProgramacion3,
                "CalidadSoftware" => locators.CalidadSoftware,
                _ => throw new ArgumentException($"Materia '{materiaKey}' no reconocida")
            };
            Actions.ViewTheElement(materia);
            materia.WaitUntilClickable().Click();
        }

        [Test]
        public void TestW3()
        {

            var w3 = Environment.GetEnvironmentVariable("W3_URL") ?? "W3_URL";
            Actions.GoToPage(w3);
            //Actions.WaitUntilVisible(selectors.TextArea).Clear();
            Actions.SwitchToFrame(locators.IFrame);
            //Actions.SelectOptionByText(selectors.Options, "Option 2");
            Actions.WaitUntilClickable(locators.ButtonInFrame).Click();
            Actions.WaitForAlertsAndConfirm();

        }
        [Test]
        public void Ciudadania()
        {
            Actions.GoToPage("https://prenotami.esteri.it/");
            Actions.WaitLoadFullPage();
            var mail = Environment.GetEnvironmentVariable("MAIL") ?? "MAIL";
            var password = Environment.GetEnvironmentVariable("PASSWORD") ?? "PASS";
            Actions.WaitUntilVisible(locators.LoginEmail).SendKeys(mail);
            Actions.WaitUntilVisible(locators.LoginPassword).SendKeys(password);
            Actions.WaitUntilClickable(locators.Avanti).Click();
            locators.SpanishLanguage.WaitUntilClickable().Click();
            locators.Reservas.WaitUntilClickable().Click();
            locators.ReservarTurno.WaitUntilClickable().Click();

            var encontreLugar = false; int i = 0;
            while (!encontreLugar && i < 200)
            {
                try
                {
                    var okButton = Actions.WaitUntilVisible(locators.BotonOk, 20);
                    okButton.WaitUntilClickable().Click();
                    Actions.Sleep();
                    Actions.Refresh();
                    Actions.WaitUntilClickable(locators.ReservarTurno, 15).Click();
                    i++;
                }
                catch (Exception)
                {
                    Debug.WriteLine("RESERVA DISPONIBLE");
                    encontreLugar = true;
                }

            }
            Actions.Sleep(2);
            //var popUp = Actions.WaitUntilVisible(locators.PopUp, 20);
            //string text = popUp.Text;
            //Assert.IsTrue(text.Equals("Sorry, all appointments for this service are currently booked.Please check again tomorrow for cancellations or new appointments."));

        }
        private void LogIn(string user, string password)
        {
            Actions.WaitUntilClickable(locators.AccederDos).Click();
            var text = Actions.WaitUntilClickable(locators.UserName).GetDomAttribute("id");
            Assert.That(Actions.WaitUntilClickable(locators.UserName).GetDomAttribute("id"), Is.EqualTo("username"));
            locators.UserName.SendKeys(user);
            locators.Password.SendKeys(password);
            locators.LogInButton.WaitUntilClickable().Click();
        }
    }
}