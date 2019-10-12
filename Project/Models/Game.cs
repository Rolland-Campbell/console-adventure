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
      IRoom Room0 = new Room("Room 0", "desc0");
      IRoom Room1 = new Room("Room 1", "desc1");
      IRoom Room2 = new Room("Room 2", "desc2");
      IRoom Room3 = new Room("Room 3", "desc3");

      //Connecting Rooms
      Room0.AddExits("east", Room1);

      Room1.AddExits("west", Room0);
      Room1.AddExits("east", Room2);

      Room2.AddExits("east", Room3);
      Room2.AddExits("west", Room1);

      Room3.AddExits("west", Room2);

      //Add items
      Item Item1 = new Item("item1", "itemdesc1");

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
      System.Console.WriteLine("Welcome weary traveller");
    }
  }
}