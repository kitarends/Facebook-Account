using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook_Activity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChromeOptions optionsProfile = new ChromeOptions();
            optionsProfile.AddArgument(@"--user-data-dir=C:\Users\vitamin\AppData\Local\Temp\scoped_dir10812_21545"); //--user-data-dir=C:\Users\vitamin\AppData\Local\Google\Chrome\User Data\
            IWebDriver driver = new ChromeDriver(optionsProfile);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10000);
            driver.Navigate().GoToUrl("https://facebook.com");
            //get list users content
            IReadOnlyList<IWebElement> userContents = driver.FindElements(By.XPath("//div[contains(@class,'userContentWrapper')]"));

            IReadOnlyList<IWebElement> likeelements = driver.FindElements(By.XPath("//a[@data-testid='fb-ufi-likelink'][@role='button']"));

            IReadOnlyList<IWebElement> abc = driver.FindElements(By.XPath("//div[contains(@class,'UFIAddCommentInput')]/input[@name='add_comment_text']"));

            //like, cmt, share for each content
            foreach (IWebElement content in userContents)
            {
                try
                {
                    IWebElement clicklike = content.FindElement(By.XPath("//a[@data-testid='fb-ufi-likelink'][@role='button'][contains(@class,'UFILikeLink')]"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].click()", clicklike);
                    //a[@data-testid='fb-ufi-likelink'][@role='button'][contains(@class,'UFILikeLink')]
                    Thread.Sleep(1000);
                    IWebElement clickcomment = content.FindElement(By.XPath("//div[contains(@class,'UFIAddCommentInput')]/input[@name='add_comment_text']"));
                    js.ExecuteScript("arguments[0].click()", clickcomment);
                    content.FindElement(By.XPath("//div[@contenteditable='true']")).SendKeys("test");
                } catch (Exception ee)
                {
                    Console.WriteLine(ee.ToString());
                }
                
            }
        }
    }
}
