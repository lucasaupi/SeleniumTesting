using OpenQA.Selenium;
using TestsProject;

namespace Selenium
{
    public class Locators
    {
        private readonly IWebDriver driver;
        public Locators(IWebDriver driver)
        {
            this.driver = driver;
        }
        public readonly By AccederDos = By.XPath("//div[@class='usermenu']//span[@class='login pl-2']//a[text()='Log in']");
        public IWebElement UserName => Actions.WaitUntilClickeable(By.Id("username"));
        public IWebElement Password => Actions.WaitUntilClickeable(By.Id("password"));
        public readonly By LogInButton = By.Id("loginbtn");
        // Paneles y sus botones y asistencia
        public readonly By PanelDerecho = By.XPath("//button[@class='btn icon-no-margin' and @title='Abrir cajón de bloques']");
        public readonly By PanelIzquierdo = By.XPath("//button[@class='btn icon-no-margin' and @data-original-title='Abrir índice del curso']");
        public readonly By Asistencia = By.PartialLinkText("Asistencia");
        public readonly By EnviarAsistencia = By.PartialLinkText("Enviar asistencia");
        public readonly By Present = By.Id("id_status_9921");
        public readonly By GuardarAsistencia = By.Id("id_submitbutton");
        // Materias
        public readonly By Programacion3 = By.PartialLinkText("PR3-2025-1");
        public readonly By ProyectoFinal = By.PartialLinkText("PRF-2025-1");
        public readonly By TallerProgramacion3 = By.PartialLinkText("TP3-2025-1");
        public readonly By CalidadSoftware = By.PartialLinkText("CSO-2025-1");

        // Extras
        public readonly By EvaluacionesGenerales = By.PartialLinkText("Evaluaciones Generales");
        public readonly By SimulacroParcial = By.PartialLinkText("Simulacro 1er Parcial");
        public readonly By SegundoFinal = By.CssSelector("a.aalink.stretched-link");
        public readonly By IFrame = By.XPath("//iframe[@frameborder='0' and @allowfullscreen='true']");
        public readonly By ButtonInFrame = By.CssSelector("button[onclick='myFunction()']");
        public readonly By Options = By.Id("options");
        public readonly By TextArea = By.Id("textareaCode");
        // Prenotami
        public readonly By SpanishLanguage = By.PartialLinkText("SPA");
        public readonly By Reservas = By.Id("advanced");
        public readonly By ReservarTurno = By.CssSelector("#dataTableServices > tbody > tr:nth-child(2) > td:nth-child(4) > a > button");
        public readonly By PopUp = By.XPath("//div[@id='jconfirm-box27203']/div");
        public readonly By PopUpContainer = By.CssSelector("body > div.jconfirm.jconfirm-light.jconfirm-open > div.jconfirm-scrollpane > div > div > div > div > div > div > div");
        public readonly By BotonOk = By.XPath("//button[@type='button' and @class='btn btn-blue' and text()='ok']");
        public readonly By LoginEmail = By.Id("login-email");
        public readonly By LoginPassword = By.Id("login-password");
        public readonly By Avanti = By.XPath("//button[@type='submit' and contains(@class, 'button primary') and text()='Avanti']");


    }
}
