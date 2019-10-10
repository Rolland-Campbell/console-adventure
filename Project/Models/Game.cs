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
      Room Room0 = new Room("Room 0", "desc0");
      Room Room1 = new Room("Room 1", "desc1");
      Room Room2 = new Room("Room 2", "desc2");
      Room Room3 = new Room("Room 3", "desc3");

      //Connecting Rooms
      Room0.AddExits(Room1);

      Room1.AddExits(Room0);
      Room1.AddExits(Room2);

      Room2.AddExits(Room3);
      Room2.AddExits(Room1);

      Room3.AddExits(Room2);

      //Add items to Rooms
      Item Item1 = new Item("sword", "A glorious Claymore, trimmed in gold");

      CurrentRoom = Room0;
    }
  }
}