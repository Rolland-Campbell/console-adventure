using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public bool Trapped { get; set; }

    public void AddExits(string direction, IRoom room)
    {
      Exits.Add(direction, room);
    }
    // public void AddItems(Item)
    // {
    //   Items.Add();
    // }

    public Room(string name, string description, bool trapped)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
      Trapped = trapped;
    }
  }
}