using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

class Program
{
    static void Main(string[] args)
    {
        ChromeDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        // lista nazwami miast(5)pogoda

        List<string> listaMiast = ["Warszawa", "Poznań", "Kraków", "Wrocław", "Katowice"];

        // przekierowanie na google
       driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");
        // znaleźienie elementu zgody na stronie 
        IWebElement zgoda = driver.FindElement(By.XPath("//*[@id=\"L2AGLb\"]/div"));
        // kliknięcie w ten element
        zgoda.Click();
        //pętal for - przejście po każdym elemencie z listy 

        for (int i = 0; i < listaMiast.Count; i++)
        {
            // kliknięcie  w wyszukiwarkę 
            IWebElement wyszukiwarka = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div[1]/div[2]/textarea"));
            wyszukiwarka.Click();
            // wprowadzenie wartości z listy 
            wyszukiwarka.SendKeys(listaMiast[i] + " pogoda");
            // kliknięcie enter
            wyszukiwarka.SendKeys(Keys.Enter);
            if (i == 0)
            {
                Console.WriteLine("Po przejściu weryfikacji naciśnij \"enter\"");
                Console.ReadLine();
            }
            //znaleźienie elemnetu za stronie
            IWebElement pogoda = driver.FindElement(By.XPath("/html/body/div[3]/div/div[12]/div/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[1]/div[1]/div/div[1]/span[1]"));
            //przerobienei elementu na tekst

            // wypisanie rezultatu (elementu z listy + pogody)
            Console.WriteLine("Pogoda w: " + listaMiast[i] + " wynosi " + pogoda.Text + " c ");
            // nawigacja do google
            driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");
        }
        //  informacja koniec 

        // dodatkowe wyjątek sprawdzneie czy nie jesteś robotem 
    }
}

    //class Program
    //{
    //    public static List<string> CreateList()
    //    {
    //        return new List<string>();
    //    }

    //    static void Main(string[] args)
    //    {

    //        // Stworzenie tabeli z miastami 

    //        List<string> lista_walut = ["USD", "EUR", "GBP", "CHF", "AUD"]; // - Tu można to zrobić na dwa sposoby 

    //        List<string> lista_walut2 = new List<string>(["USD", "EUR", "GBP", "CHF", "AUD"]); // - Tu można to zrobić na dwa sposoby 

    //        List<string> lista_walut3 = CreateList();
    //        lista_walut3.AddRange(["USD", "EUR", "GBP", "CHF", "AUD"]);

    //        string s = "adsad";
    //        int i = 23;


    //            //Tworzenie istancji klasy

    //        ChromeDriver driver = new ChromeDriver();

    //        WebDriverWait driverWithWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

    //        driver.Manage().Window.Maximize();

    //        //Otwarcie googla
    //        driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");

    //        //Akceptacja regulaminu - konkretny element IWebElement 

    //        IWebElement akceptacja_regulaminu = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/div[1]/button[2]/div"));

    //        //Kliknięcie elementu
    //        akceptacja_regulaminu.Click();

    //        //Stworzenie pętli gdzie przechodzącej po liście 
    //        for (int i = 0; i < lista_walut.Count; i++)
    //        {
    //            //kliknięcie w wyszukiwarke
    //            IWebElement wyszukiwarka = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div[1]/div[2]/textarea"));

    //            //Dodanie pierwszego elementu z listy 
    //            wyszukiwarka.SendKeys(lista_walut[i]);

    //            //kliknięci eenter, aby wyszukać
    //            wyszukiwarka.SendKeys(Keys.Enter);
    //            // weryfikacja przy pierwszym wyszukiwaniu
    //            if (i == 0)
    //            {
    //                Console.WriteLine("Po przejściu weryfikacji kliknij enter");
    //                Console.ReadLine();
    //            }
    //            //Thread.Sleep(5000);
    //            //Pobranie elementu ze strony - waluty
    //            //IWebElement currencyRate = driver.FindElement(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]"));
    //            IWebElement currencyRate = driverWithWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]")));

    //            //Wypisanie na konsoli wyniku - łącznie 
    //            Console.WriteLine(lista_walut[i] +  " to "  + currencyRate.Text);

    //            //przekieroweanie na stronę googla 
    //            driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");
    //        }

    //        Console.WriteLine("Koniec");


    ////Console.WriteLine("Początek zadania lista walut:"); /// dodanie informacji co się dzieje 
    ////List<string> list = ["USD", "EUR", "GBP", "CHF", "CZK"];   

    ////ChromeDriver driver = new ChromeDriver();
    ////driver.Manage().Window.Maximize(); 

    ////driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl"); /// przekierowanie na stronę "google"

    //// uleszenie 
    ////var driverWithWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));



    ////IWebElement akceptacjaRegulaminu = driver.FindElement(By.XPath("/ html / body / div[2] / div[2] / div[3] / span / div / div / div / div[3] / div[1] / button[2] / div"));
    ////akceptacjaRegulaminu.Click();

    ////Console.WriteLine("Po przejściu przez weryfikację naciśnij enter");
    ////Console.ReadLine();
    ////                                            foreach (var waluta in list)
    ////                                            {
    ////                                                / wprowadzenie pierwszego elementu z listy do wyszukiwarki 
    ////                                                IWebElement searchBar = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div[1]/div[2]/textarea"));
    ////                                                searchBar.SendKeys(waluta);
    ////                                                / kliknięcie enter, aby wyszukać
    ////                                                searchBar.SendKeys(Keys.Enter);

    ////                                                 CAPTCHA
    ////                                                 Tylko za 1 razem
    ////                                                if (waluta == list[0])
    ////                                                {
    ////                                                    Console.WriteLine("Po przejściu przez weryfikację naciśnij enter");
    ////                                                    Console.ReadLine();
    ////                                                }

    ////                                                IWebElement currencyRate = driverWithWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]")));
    ////                                                Thread.Sleep(5000);
    ////                                                / znaleźienie odpowiedniego elemnetu  na stronie 
    ////                                                element = driver.FindElement(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]"));
    ////                                                / wypisanie elementu (kursu)
    ////                                                string elementWal = currencyRate.Text;
    ////                                                / wypisanie elementu na konsoli razem z walutą 
    ////                                                Console.WriteLine(waluta + ' ' + elementWal);

    ////                                                driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");
    ////                                            }
    ////for (int i = 0; i < list.Count; i++) /// pętla, która przechodzi po każdym elemencie z listy 
    ////{
    ////    / wprowadzenie pierwszego elementu z listy do wyszukiwarki 
    ////    IWebElement element = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div[1]/div[2]/textarea"));
    ////    element.SendKeys(list[i]);
    ////    / kliknięcie enter, aby wyszukać
    ////    element.SendKeys(Keys.Enter);

    ////     CAPTCHA
    ////     Tylko za 1 razem
    ////    if( i == 0)
    ////    {
    ////        Console.WriteLine("Po przejściu przez weryfikację naciśnij enter");
    ////        Console.ReadLine();
    ////    }
    ////    element = driverWithWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]")));
    ////    Thread.Sleep(5000);
    ////    / znaleźienie odpowiedniego elemnetu  na stronie 
    ////    element = driver.FindElement(By.XPath("//*[@id=\"knowledge-currency__updatable-data-column\"]/div[1]/div[2]/span[1]"));
    ////    / wypisanie elementu (kursu)
    ////    string element_wal = element.Text;
    ////    / wypisanie elementu na konsoli razem z walutą 
    ////    Console.WriteLine(list[i] + ' ' + element_wal);

    ////    driver.Navigate().GoToUrl("https://www.google.pl/?hl=pl");
    ////}



