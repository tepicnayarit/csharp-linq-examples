using LinqCourse;
using System.Reflection;


var games = new List<Game>
{
    new Game {Title="The Legend of Zelda", Genre = "RPG", RealeaseYear = 1986, Rating = 9.5, Price = 60},
    new Game {Title="Super Mario Bros", Genre = "Platformer", RealeaseYear = 1985, Rating = 9.2, Price = 50},
    new Game {Title="Elden Ring", Genre = "RPG", RealeaseYear = 2022, Rating = 9.8, Price = 55},
    new Game {Title="Stardew Valley", Genre = "Simulation", RealeaseYear = 2016, Rating = 9.0, Price = 15},
    new Game {Title="Tetris", Genre = "Puzzle", RealeaseYear = 1984, Rating = 8.9, Price = 10}
};
//Con List
Console.WriteLine("-----List-----");
List<String> allGames  = new List<String>();
foreach (Game game in games)
{
    allGames.Add(game.Title);
}
foreach (var title in allGames)
{
    Console.WriteLine(title);
}

//Con Linq
Console.WriteLine("-----Using Select-----");
var allTitles = games.Select(x => x.Title);
foreach (var title in allTitles)
{
    Console.WriteLine(title);
}

//All RPG Games WHERE
Console.WriteLine("-----All RPG Games Where-----");
var rpgGames = games.Where(game => game.Genre == "RPG");
foreach (var game in rpgGames) {  
    
    Console.WriteLine(game.Title); 

}

//Any Function Devuelve true or false si al menos un objeto cumple la condición
Console.WriteLine("-----Any Function Devuelve true or false si se cumple la condición-----");
var modernGamesExist = games.Any(game => game.RealeaseYear > 2000);
Console.WriteLine($"Are there any modern games? {modernGamesExist}");

//Order By ReleaseYear
Console.WriteLine("-----OrderBy Function by ReleaseYear-----");
var sortedByYear = games.OrderByDescending(g => g.RealeaseYear);
foreach (var game in sortedByYear) {  
    Console.WriteLine($"{game.Title} {game.RealeaseYear}"); 
}

//Funciones
Console.WriteLine("-----Funciones-----");
var averagePrice = games.Average(g => g.Price);
Console.WriteLine($"The average game price is: {averagePrice}");

Console.WriteLine("-----Highest Rating  Max First-----");
var highestRating = games.Max(g => g.Rating);   
var bestGame = games.First(g => g.Rating == highestRating);
Console.WriteLine($"BEst Game is: {bestGame.Title}  {bestGame.Rating}");

Console.WriteLine("----- Group By Genre -----");
var gamesByGroup = games.GroupBy(g => g.Genre);
foreach (var group in gamesByGroup)
{
    Console.WriteLine($"Genre: {group.Key}");
    foreach (var game in group) 
    {
        Console.WriteLine(game.Title);
    }

}

Console.WriteLine("----- Multiple Functions -----");
var budgetAdventureGames = games
    .Where(g => g.Genre == "RPG" && g.Price <= 60)
    .OrderByDescending(g => g.Rating)
    .Select(g => $"{g.Title} - {g.Price} - {g.Rating}");
foreach(var game in budgetAdventureGames) {
    Console.WriteLine(game);
}

Console.WriteLine("----- Paginated Games Skip 2 and then Take 2 -----");
var paginatedGames = games.Skip(2).Take(2);
foreach(var game in paginatedGames)
{
    Console.WriteLine(game.Title);
}

Console.WriteLine("----- Syntax similar to SQL -----");
var adventureGames = games.Where(g => g.Genre == "RPG");

var adventureGamesQuery = from g in games where g.Genre == "RPG" select g;
foreach(var game in adventureGamesQuery) { 
    Console.WriteLine(game.Title); 
}

Console.WriteLine("----- Cheapest Game OrderBy and take the First -----");
var cheapestGame = games.OrderBy(g  => g.Price).First();
Console.WriteLine($"{cheapestGame.Title} - {cheapestGame.Price} - {cheapestGame.Rating}");

Console.WriteLine("----- Select distinct if one genre is repeated show it only once -----");
var genres = games.Select(g => g.Genre).Distinct();
foreach(var genre in genres)
{
    Console.WriteLine(genre);
}