using HtmlAgilityPack;
using System;
using System.Xml.Linq;

namespace Car_searcher;

public class CarScraper
{
    public IEnumerable<CarModel> GetCars()
    {
        var web = new HtmlWeb();

        string? nextPageUrl = null;
        do
        {
            if (nextPageUrl != null)
            {
                SearchDetails.link = "https://olx.pl" + nextPageUrl;
            }
            var document = web.Load(SearchDetails.link);
            var cars = document.QuerySelectorAll("div.css-oukcj3 div.css-1sw7q4x");
            foreach (var car in cars)
            {
                CarModel carModel = new CarModel();
                carModel.link = car.QuerySelector("a").Attributes["href"].Value;
                carModel.decription = car.QuerySelector("a div div div.css-1apmciz div h6").InnerText;
                carModel.price = car.QuerySelector("a div div div.css-1apmciz div p").InnerHtml;

                yield return carModel;
            }

            var element = document
                .QuerySelector("#mainContent > div.css-1nvt13t > form > div:nth-child(5) > div > section.css-j8u5qq > div > ul > a:nth-child(7)");

            if (element != null)
            {
                nextPageUrl = element.Attributes["href"].Value;
            }
            else
            {
                nextPageUrl = null;
            }
        } while (nextPageUrl != null);
    }
}