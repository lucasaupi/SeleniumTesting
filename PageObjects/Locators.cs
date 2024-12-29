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
        public IWebElement UserName => driver.FindElement(By.Id("username")).WaitUntilClickeable();
        public IWebElement Password => driver.FindElement(By.Id("password")).WaitUntilClickeable();
        public readonly By LogInButton = By.Id("loginbtn");
        public readonly By OpenPanel = By.XPath("//button[@class='btn icon-no-margin' and @title='Abrir cajón de bloques']");
        public readonly By ProgramacionDos = By.PartialLinkText("PR2-2024-2");
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
