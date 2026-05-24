# Car-searcher

CLI application for searching car listings from OLX using web scraping.  
The tool allows filtering results by keywords and price range, then displays matching offers in the console.

## Features

- Search listings based on user query
- Filter results by minimum and maximum price
- Web scraping of OLX search results
- Display parsed offers (title, price, link)
- Simple interactive console menu

## How it works

User provides search parameters in a CLI menu:
- search query (e.g. car model or keyword)
- minimum price
- maximum price

The application builds a search URL, scrapes results from OLX, and parses listing data into structured objects.

## Technologies

- C#
- .NET Console Application
- Web scraping (HTML parsing)
- Console UI

## Project structure
