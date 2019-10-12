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
        System.Console.WriteLine("once"); //FIXME make a graphic for game. call template here.
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
          break;
        case "q":
          Console.Clear();
          Environment.Exit(0);
          break;
      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      System.Console.WriteLine("test");
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

  }
}