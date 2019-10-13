using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private Game _game { get; set; }
    public List<string> Messages { get; set; }

    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        Messages.Add($"You have moved to {_game.CurrentRoom.Name}");
      }
      else Messages.Add("Didn't move");
    }
    public void Help()
    {
      string help = @"
Commands:
    i: Show your current inventory.
    l: Look around for s description of the current room.
    get (item name): Picks up item with that name.
    go (direction [North, East, West, South]): Moves you to the next room.
    use (item name): Use the item from your inventory.
    q: Quit the game.
      ";
      Messages.Add(help);
    }

    public void Inventory()
    {
      var items = _game.CurrentPlayer.Inventory;
      string template = "Your current inventory: \n";
      if (items.Count > 0)
      {
        foreach (var i in items)
        {
          template += $"{i.Name}: {i.Description} \n";
        }
      }
      else
      {
        Messages.Add("You have nothing in your inventory.");
      }
      Messages.Add(template);
    }

    public void Look()
    {
      Messages.Add($"{_game.CurrentRoom.Description} \n");
      var exits = _game.CurrentRoom.Exits;
      string template = "This room has the following exits: \n";
      foreach (var e in exits)
      {
        template += $"{e.Key} \n";
      }
      Messages.Add(template);

      var items = _game.CurrentRoom.Items;
      string templateItem = "The following items in the room: \n";
      foreach (var i in items)
      {
        templateItem += $"{i.Name}: {i.Description} \n";
      }
      Messages.Add(templateItem);
    }

    public void Quit()
    {
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
    }

    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item i = new Item("", ""); //created instance
      if (_game.CurrentRoom.Items.Count > 0) //checked if items are in room
      {
        foreach (Item item in _game.CurrentRoom.Items) //iterate through items in room
        {
          if (item.Name == itemName) //compare typed name, with item names in room list.
          {
            i = item;
          }
          else
          {
            Messages.Add("That item is not in this room");
          }
        }
        if (i.Name.Length > 1)
        {
          _game.CurrentPlayer.Inventory.Add(i); //add item to inventory
          _game.CurrentRoom.Items.Remove(i); //Remove from room list
        }
      }
      else
      {
        Messages.Add("There are no items to take...");
      }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {

      Item i = new Item("", "");
      if (_game.CurrentPlayer.Inventory.Count > 0) //checked if items are in player inv
      {
        foreach (Item item in _game.CurrentPlayer.Inventory) //iterate through inv
        {
          if (item.Name == itemName) //compare typed name, with items in inv.
          {
            i = item;
          }
        }
      }
      else
      {
        Messages.Add("You do not have that item.");
      }
    }
  }
}
