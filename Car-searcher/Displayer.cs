namespace Car_searcher;

public class Displayer
{
    public void displayMenu(SearchDetails details)
    {
        Console.WriteLine("MENU:");
        Console.WriteLine("1. Change search query");
        Console.WriteLine("2. Change lowest price");
        Console.WriteLine("3. Change highest price");
        Console.WriteLine("4. Search");
        Console.WriteLine("");
        Console.WriteLine("Write a number, to choose an option");
    }
}