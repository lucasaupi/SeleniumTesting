using OpenQA.Selenium;

namespace Selenium
{
    public class Locators
    {
        public readonly By AccederDos = By.XPath("//div[@class='usermenu']//span[@class='login pl-2']//a[text()='Log in']");
        public readonly By UserName = By.Id("username");
        public readonly By Password = By.Id("password");
        public readonly By LogInButton = By.Id("loginbtn");
        public readonly By OpenPanel = By.XPath("//button[@class='btn icon-no-margin' and @title='Abrir cajón de bloques']");
        public readonly By ProgramacionDos = By.XPath("//div[@class='card-text content mt-3']//a[@title='PR2-2024-2']");
        public readonly By EvaluacionesGenerales = By.XPath("//a[@class='nav-link' and @title='Evaluaciones Generales']");
        public readonly By SimulacroParcial = By.XPath("//span[@class='instancename' and contains (text(), '2024 2C BE-21B - Simulacro 1er Parcial')]");
        public readonly By SegundoFinal = By.CssSelector("a.aalink.stretched-link");
        public readonly By IFrame = By.XPath("//iframe[@frameborder='0' and @allowfullscreen='true']");
        public readonly By ButtonInFrame = By.CssSelector("button[onclick='myFunction()']");
        public readonly By Options = By.Id("options");
        public readonly By TextArea = By.Id("textareaCode");


    }
}
