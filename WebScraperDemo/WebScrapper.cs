using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebScraperDemo
{

    struct FilmData
    {
        public string name;
        public float rating;
        public string numOfVotes;
        public string releaseDate;

    }
    class WebScrapper
    {
        public static IWebDriver driver;
        public static int numberOfLoops;
        
        public WebScrapper()  
        {
            driver = new EdgeDriver();
            numberOfLoops = 0;
        }

        public FilmData[] RunSearch(int numberOfFilms)
        {
            numberOfLoops = (numberOfFilms / 50);
            driver.Navigate().GoToUrl("https://www.imdb.com/search/title/?title_type=feature&user_rating=1,10");
            Thread.Sleep(500);

            var accept = FindElement(By.XPath("//*[@id=\"__next\"]/div/div/div[2]/div/button[2]"));
            accept.Click();

            ExpandSearch(By.XPath("//*[@id=\"__next\"]/main/div[2]/div[3]/section/section/div/section/section/div[2]/div/section/div[2]/div[2]/div[2]/div/span/button"), numberOfLoops);
            

            var filmName = driver.FindElements(By.XPath("//*[@id=\"__next\"]/main/div[2]/div[3]/section/section/div/section/section/div[2]/div/section/div[2]/div[2]/ul/li/div/div/div/div[1]/div[2]/div[1]/a/h3"));
            var releaseDate = driver.FindElements(By.XPath("/html/body/div[2]/main/div[2]/div[3]/section/section/div/section/section/div[2]/div/section/div[2]/div[2]/ul/li/div/div/div/div[1]/div[2]/div[2]/span[1]"));
            var filmRating = driver.FindElements(By.XPath("/html/body/div[2]/main/div[2]/div[3]/section/section/div/section/section/div[2]/div/section/div[2]/div[2]/ul/li/div/div/div/div[1]/div[2]/span/div/span"));

            FilmData[] results = new FilmData[numberOfFilms];

            for (int i = 0; i<numberOfFilms; i++)
            {
                results[i].name = DataFile.FilterNameString(filmName[i].Text);
                results[i].releaseDate = releaseDate[i].Text;
                results[i].rating = float.Parse(filmRating[i].Text.Substring(0, 3));
                results[i].numOfVotes = filmRating[i].Text.Substring(7, filmRating[i].Text.IndexOf(")") - 7);

            }

            driver.Quit();

            return results;
        }
        static IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            while (true)
            {
                Thread.Sleep(100);
                var elements = driver.FindElements(by);
                if (elements.Count > 0)
                {
                    return elements;
                }
            }
        }
        static IWebElement FindElement(By by)
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(100);
                    var element = driver.FindElement(by);

                    if (element != null)
                    {
                        return element;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }
        }

        static void ExpandSearch(By by, int number)
        {

            Thread.Sleep(500);

            while (number > 0)
            {
                Thread.Sleep(10);

                var element = driver.FindElement(by);

                if (element != null && element.GetAttribute("aria-disabled") == "false")
                {
                    element.Click();
                    number--;
                }

            }

        }
    }
}