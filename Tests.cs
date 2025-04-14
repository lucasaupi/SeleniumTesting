using OpenQA.Selenium;
using System.Diagnostics;

namespace TestsProject
{
    [TestFixture]
    public class Tests : TestBase
    {
        [TestCase("PF")]
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
            //Actions.ViewTheElement(locators.PanelDerecho);
            //locators.PanelDerecho.WaitUntilClickeable().Click();
            SeleccionarMateria(materia);

            Actions.ViewTheElement(locators.Asistencia);
            locators.Asistencia.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.EnviarAsistencia);
            locators.EnviarAsistencia.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.Present);
            locators.Present.WaitUntilClickeable().Click();
            Actions.ViewTheElement(locators.GuardarAsistencia);
            locators.GuardarAsistencia.WaitUntilClickeable().Click();
            Actions.Sleep(2);
        }

        private void SeleccionarMateria( string materiaKey)
        {
            By materia = materiaKey switch
            {
                "PF" => locators.ProyectoFinal,
                "P3" => locators.Programacion3,
                "TP3" => locators.TallerProgramacion3,
                "CalidadSoftware" => locators.CalidadSoftware,
                _ => throw new ArgumentException($"Materia '{materiaKey}' no reconocida")
            };
            Actions.ViewTheElement(materia);
            materia.WaitUntilClickeable().Click();
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
        [Test]
        public void Ciudadania()
        {
            Actions.GoToPage("https://prenotami.esteri.it/");
            Actions.WaitLoadFullPage();
            var mail = Environment.GetEnvironmentVariable("MAIL") ?? "MAIL";
            var password = Environment.GetEnvironmentVariable("PASSWORD") ?? "PASS";
            Actions.WaitUntilVisible(locators.LoginEmail).SendKeys(mail);
            Actions.WaitUntilVisible(locators.LoginPassword).SendKeys(password);
            Actions.WaitUntilClickeable(locators.Avanti).Click();
            locators.SpanishLanguage.WaitUntilClickeable().Click();
            locators.Reservas.WaitUntilClickeable().Click();
            locators.ReservarTurno.WaitUntilClickeable().Click();

            var encontreLugar = false; int i = 0;
            while (!encontreLugar && i < 200)
            {
                try
                {
                    var okButton = Actions.WaitUntilVisible(locators.BotonOk, 20);
                    okButton.WaitUntilClickeable().Click();
                    Actions.Sleep();
                    Actions.Refresh();
                    Actions.WaitUntilClickeable(locators.ReservarTurno, 15).Click();
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
            Actions.WaitUntilClickeable(locators.AccederDos).Click();
            var text = Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id");
            Assert.IsTrue(Actions.WaitUntilClickeable(locators.UserName).GetDomAttribute("id").Equals("username"));
            locators.UserName.SendKeys(user);
            locators.Password.SendKeys(password);
            locators.LogInButton.WaitUntilClickeable().Click();
        }
    }
}