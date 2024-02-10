namespace Car_searcher;

class Program
{
    static void Main(string[] args)
    {
        Displayer displayer = new Displayer();
        SearchDetails carDetails = new SearchDetails();
        var loop = true;
        int priceLowest = 0, priceHighest = Int32.MaxValue;

        while (loop)
        {
            displayer.displayMenu(carDetails);
            var input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Input query:");
                    carDetails.searchQuery = Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Input lowest price:");
                    var lowestPriceInput = Console.ReadLine();
                    if (int.TryParse(lowestPriceInput, out priceLowest))
                    {
                        if (priceLowest < priceHighest)
                        {
                            carDetails.priceLowest = lowestPriceInput.Trim();
                        }
                        else
                        {
                            int.TryParse(carDetails.priceLowest, out priceLowest);
                        }
                    }
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Input highest price");
                    var highestPriceInput = Console.ReadLine();
                    if (int.TryParse(highestPriceInput, out priceHighest))
                    {
                        if (priceLowest < priceHighest)
                        {
                            carDetails.priceHighest = highestPriceInput;
                        }
                        else
                        {
                            int.TryParse(carDetails.priceHighest, out priceHighest);
                        }
                    }

                    Console.Clear();
                    break;
                case "4":
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }
        carDetails.refactorLink(carDetails);
        Console.WriteLine($"Link: {SearchDetails.link}");

        CarScraper carScraper = new CarScraper();
        List<CarModel> carModels = carScraper.GetCars().ToList();

        foreach (var carModel in carModels)
        {
            Console.WriteLine($"Decription: {carModel.decription}");
            Console.WriteLine($"Price: {carModel.price}");
            if (carModel.link[0] == '/')
            {
                Console.WriteLine($"Link: https://olx.pl{carModel.link}");
            }
            else
            {
                Console.WriteLine($"Link: {carModel.link}");
            }

            Console.WriteLine("");
        }
    }
}