using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

var excel = new Application();
// Create a new workbook
var workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
// Get the first worksheet in the workbook
var worksheet = (Worksheet)workbook.Worksheets[1];
worksheet.Name = "Polish Weather";

var chromeOptions = new ChromeOptions();
chromeOptions.AddArguments("--headless=new");

var driver = new ChromeDriver(chromeOptions);
var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


driver.Navigate().GoToUrl("https://gist.github.com/kqf/782e04ee4b526d266ad8b0452a9f20bc");

IWebElement table_tbody = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#file-poland-csv > div.Box-body.p-0.blob-wrapper.data.type-csv.gist-border-0 > div.markdown-body > table > tbody")));

IList<IWebElement> tbody_trs = table_tbody.FindElements(By.TagName("tr"));

var cities = new List<string>();

foreach (var row in tbody_trs)
{
    IList<IWebElement> tds = row.FindElements(By.TagName("td"));
    cities.Add(tds[1].Text);
}

for (int i = 0; i < cities.Count; i++)
{
    string temperature;
    if (i == 0)
    {
        temperature = GetWeather(driver, wait, cities[i], true);
    }
    else
    {
        temperature = GetWeather(driver, wait, cities[i], false);
    }

    Console.WriteLine($"{cities[i]} - {temperature}");
}

// -------------- metoda

static string GetWeather(ChromeDriver driver, WebDriverWait wait, string city_name, bool checkForRodo)
{
    driver.Navigate().GoToUrl("https://pogoda.interia.pl/");

    if (checkForRodo)
    {
        // Wait for the RODO popup button to be visible and clickable
        var agreeButton = wait.Until(ExpectedConditions.ElementToBeClickable(
            By.CssSelector("button.rodo-popup-agree.rodo-popup-main-agree")
        ));

        // Click the “Przejdź do serwisu” button
        agreeButton.Click();
    }

    var input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("weather-currently-input-text-1")));
    input.Click();

    // Clear and enter a value
    input.Clear();
    input.SendKeys(city_name);

    var dropdown = wait.Until(ExpectedConditions
        .ElementIsVisible(By.CssSelector(".suggest-city-result:not(.hidden)")));

    var firstSuggestion = dropdown.FindElement(By.CssSelector("li:first-child a"));
    firstSuggestion.Click();

    var weather_elem = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#weather-currently > div.weather-currently-middle > div.weather-currently-middle-today-wrapper > div > div.weather-currently-temp")));

    return weather_elem.Text;
}

//--------------------------

// Save the workbook to a file
workbook.SaveAs("Pogoda_excel_selenium");
// Close the workbook and Excel application
workbook.Close();

excel.Quit();