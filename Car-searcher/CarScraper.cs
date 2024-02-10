using HtmlAgilityPack;
using System;
using System.Xml.Linq;
using static Car_searcher.SearchDetails;

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
                link = "https://olx.pl" + nextPageUrl;
                link = link.Replace("amp;", "");
            }
            var document = web.Load(link);
            var cars = document.QuerySelectorAll("div.css-oukcj3 div.css-1sw7q4x");
            foreach (var car in cars)
            {
                CarModel carModel = new CarModel();
                carModel.link = car.QuerySelector("a").Attributes["href"].Value;
                carModel.decription = car.QuerySelector("a div div div.css-1apmciz div h6").InnerText;
                carModel.price = car.QuerySelector("a div div div.css-1apmciz div p").InnerText;

                yield return carModel;
            }

            var element = document
                .QuerySelector("section.css-j8u5qq div.css-4mw0p4 ul.css-1vdlgt7 a[data-cy='pagination-forward']");

            nextPageUrl = element ? .Attributes["href"].Value;
        } while (nextPageUrl != null);
    }
}