using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      while (true)
      {
        GetUserInput();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine(@"What would you like to do?
[type h for Help, q to Quit]
      ");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "i":
          _gameService.Inventory();
          Console.Clear();
          Print();
          break;
        case "h":
          _gameService.Help();
          Console.Clear();
          Print();
          break;
        case "go":
          _gameService.Go(option);
          Console.Clear();
          Print();
          break;
        case "l":
          _gameService.Look();
          Console.Clear();
          Print();
          break;
        case "take":
          _gameService.TakeItem(option);
          Console.Clear();
          break;
        case "q":
          Console.Clear();
          Environment.Exit(0);
          break;
        case "use":
          _gameService.UseItem(option);
          Console.Clear();
          Print();
          break;
      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      System.Console.WriteLine(@"                                                    
 _______  __   __  ______    __    _  ___   __    _  _______  _______  _______ 
|  _    ||  | |  ||    _ |  |  |  | ||   | |  |  | ||   _   ||       ||       |
| |_|   ||  | |  ||   | ||  |   |_| ||   | |   |_| ||  |_|  ||_     _||    ___|
|       ||  |_|  ||   |_||_ |       ||   | |       ||       |  |   |  |   |___ 
|  _   | |       ||    __  ||  _    ||   | |  _    ||       |  |   |  |    ___|
| |_|   ||       ||   |  | || | |   ||   | | | |   ||   _   |  |   |  |   |___ 
|_______||_______||___|  |_||_|  |__||___| |_|  |__||__| |__|  |___|  |_______|
                Survive Trogdor's Layer of Doooom! and stuff...
                
                
      ");
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

  }
}