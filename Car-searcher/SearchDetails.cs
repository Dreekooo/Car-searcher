using System.Globalization;

namespace Car_searcher;

public class SearchDetails
{
    public static string link { get; set; } = "https://www.olx.pl/motoryzacja/samochody";
    public string searchQuery { get; set; } = null;
    public string priceLowest { get; set; } = "0";
    public string priceHighest { get; set; } = null;

    public void refactorLink(SearchDetails details)
    {
        int number;
        if (details.searchQuery != null)
        {
            link += "/q-" + details.searchQuery.Replace(" ", "-");
        }

        link += "/?search%5Bfilter_float_price:from%5D=" + details.priceLowest;

        if (details.priceHighest != null)
        {
            link += "&search%5Bfilter_float_price:to%5D=" + details.priceHighest;
        }
    }
}