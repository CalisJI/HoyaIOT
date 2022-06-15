using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOYA_IOT.Control
{
    public class ScapData
    {
        private string url;
        private ChromeOptions options;
        private IWebDriver Driver;
        public string ElementType{ get; set; }
        public string Attribute { get; set; }
        public string AttributeValueFind { get; set; }
        public DataTable Data { get; set; }
        public List<string> AttributeNames { get; set; }
        public ScapData(string url) 
        {
            this.url = url;
            options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
                
            };
            options.AddArgument("headless");
            options.LeaveBrowserRunning = true;
            Driver = new ChromeDriver(chromeDriverDirectory: "C:\\Program Files\\Google\\Chrome\\Application", options);
        }
        public void ScapingDataByTagName() 
        {
            try
            {
                if (AttributeNames != null && AttributeNames.Count > 0 && AttributeValueFind != "")
                {
                    Driver.Navigate().GoToUrl(url);
                    var links = Driver.FindElements(By.TagName(ElementType));
                    if (AttributeNames.Count > 0)
                    {
                        foreach (var url in links)
                        {
                            string a = url.GetAttribute(Attribute);
                            foreach (var item in AttributeNames)
                            {
                                if (a == item) 
                                {
                                    if (AttributeValueFind == "Text") 
                                    {
                                        Data.Rows[0][item] = url.Text;
                                    }
                                    else 
                                    {
                                        Data.Rows[0][item] = url.GetAttribute(AttributeValueFind);
                                    }
                                }
                            }
                           
                        }
                    }
                    
                }
                else 
                {
                    MessageBox.Show("Miss References");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
