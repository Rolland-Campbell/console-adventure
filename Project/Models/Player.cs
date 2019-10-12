using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public Player()
    {
      Inventory = new List<Item>();
    }

    public string Name { get; set; }
    public List<Item> Inventory { get; set; }
  }
}