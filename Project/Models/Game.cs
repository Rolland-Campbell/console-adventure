using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      //Creating Rooms
      IRoom Room0 = new Room("Cave Enterance", "The front of the cave... what else would it be <grumble>", false);
      IRoom Room1 = new Room("Some kinda hallway", "it has walls and stuff..you know dungeony looking", false);
      IRoom Room2 = new Room("Another Hallway!?!?", "it looks kind of like the last hallway.. not very original I would say..", false);
      IRoom Room3 = new Room("Trogdor's Layer", "You have entered the layer of the mighty Trogdor! Behold his majesticness.. and his big BEEFY arm", true);

      //Connecting Rooms
      Room0.AddExits("east", Room1);

      Room1.AddExits("west", Room0);
      Room1.AddExits("east", Room2);

      Room2.AddExits("east", Room3);
      Room2.AddExits("west", Room1);

      Room3.AddExits("west", Room2);

      //Add items
      Item Item1 = new Item("Nun-Chuck Gun", "Hmm..this is a most potent weapon..umm yeah");

      //Item locations
      Room0.Items.Add(Item1);

      CurrentRoom = Room0;
    }

    public Game()
    {
      CurrentPlayer = new Player();
      GetTemplate();
      Setup();
    }

    //FIXME change template to show graphic (will show at start screen)
    public void GetTemplate()
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
    }
  }
}