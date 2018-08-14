using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            driver.Navigate().GoToUrl("https://facebook.com");

            driver.FindElement(By.XPath("//a[@class='UFILikeLink _4x9- _4x9_ _48-k']")).Click();
        }
    }
}
