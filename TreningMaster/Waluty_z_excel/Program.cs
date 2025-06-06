using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


var excel = new Application();

var workbook = excel.Workbooks.Open("Waluty", ReadOnly: false, Editable: true);

var worksheet = (Worksheet)workbook.Worksheets[1];

int i = 1;
List<string> list_walut = new List<string>();
while (true)
{
    var cell = worksheet.Cells[i, 1];

    if (cell == null || cell.Value == null) break;

    list_walut.Add(cell.Value);
    i++;
}

ChromeDriver driver = new ChromeDriver();

WebDriverWait driverWithWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

driver.Manage().Window.Maximize();

//Otwarcie googla
driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");

//Akceptacja regulaminu - konkretny element IWebElement 

IWebElement akceptacja_regulaminu = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/div[1]/button[2]/div"));

//Kliknięcie elementu
akceptacja_regulaminu.Click();

for (int j = 0; j < list_walut.Count; j++)
{
    //kliknięcie w wyszukiwarke
    IWebElement wyszukiwarka = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div[1]/div[2]/textarea"));

    //Dodanie pierwszego elementu z listy 
    wyszukiwarka.SendKeys(list_walut[j]);

    //kliknięci eenter, aby wyszukać
    wyszukiwarka.SendKeys(Keys.Enter);
    // weryfikacja przy pierwszym wyszukiwaniu
    if (j == 0)
    {
        Console.WriteLine("Po przejściu weryfikacji kliknij enter");
        Console.ReadLine();
    }
    IWebElement currencyRate = driverWithWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]")));
   
    worksheet.Cells[j + 1, 2] = currencyRate.Text ; 

    //przekieroweanie na stronę googla 
    driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");
}

// Save the workbook to a file
workbook.SaveAs("Watuty_wynik");
// Close the workbook and Excel application
workbook.Close();

excel.Quit();