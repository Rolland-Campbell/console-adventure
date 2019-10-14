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
        Messages.Add(_game.CurrentRoom.Description);
        var items = _game.CurrentRoom.Items;
        string templateItem = "The following items are in the room: \n";
        foreach (var i in items)
        {
          templateItem += $"{i.Name}: {i.Description} \n";
        }
        Messages.Add(templateItem);
        var exits = _game.CurrentRoom.Exits;
        string template = "This room has the following exits: \n";
        foreach (var e in exits)
        {
          template += $"{e.Key} \n";
        }
        Messages.Add(template);
      }
      else
      {
        Messages.Add("You cannot go that way, try reading the exits or something... \n");
        var exits = _game.CurrentRoom.Exits;
        string template = "This room has the following exits: \n";
        foreach (var e in exits)
        {
          template += $"{e.Key} \n";
        }
        Messages.Add(template);
      }
    }
    public void Help()
    {
      string help = @"
Commands:
    i: Show your current inventory.
    l: Look around for a description of the current room.
    take (item name): Picks up item with that name.
    go (direction [North, East, West, South]): Moves you to the next room.
    use (item name): Use the item from your inventory.
    q: Quit the game.
    r: Restarts the game.
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
        Messages.Add("You have nothing in your inventory. \n");
      }
      Messages.Add(template);
    }

    public void Look()
    {
      Messages.Add($"{_game.CurrentRoom.Name} \n");
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
      _game.CurrentPlayer.Inventory.Clear();
      _game.Setup();
    }

    public void Setup(string playerName)
    {
    }

    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item i = _game.CurrentRoom.Items.Find(item => item.Name == itemName); //searches room items for typed item. Compare typed name, with item names in room list.
      if (i == null)
      {
        Messages.Add("That item is not in this room \n"); //if typed name is incorrect
        return;
      }
      _game.CurrentPlayer.Inventory.Add(i); //add item to inventory
      Messages.Add($"You picked up a {i.Name} \n");
      _game.CurrentRoom.Items.Remove(i); //Remove from room list
    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      Item i = new Item("", "");
      if (_game.CurrentPlayer.Inventory.Count > 0) //check if inv has items
      {
        foreach (Item item in _game.CurrentPlayer.Inventory) //iterate through inv
        {
          if (item.Name == itemName) //compare typed name, with items in inv.
          {
            i = item;
          }
          if (itemName != i.Name)
          {
            Messages.Add($"What is a {itemName}? You do not have one of those..\n");
          }
        }
        if (i.Name == "nunchuckgun")
        {
          _game.CurrentPlayer.Inventory.Remove(i);
          Messages.Add($"You use your {i.Name}! It seems to have had no effect... \n");
          Messages.Add($"Your {i.Name} falls to the floor... \n");
          _game.CurrentRoom.Items.Add(i);
        }
        if (i.Name == "grumblecakes")
        {
          _game.CurrentPlayer.Inventory.Remove(i); //Remove from inv
          Messages.Add($"You use your {i.Name}! \n");
          if (_game.CurrentRoom.Trapped)
          {
            Messages.Add($"The mighty Trogdor is hit with {i.Description}, Trogdor winces in pain, then gives you a thumbs-up with his big BEEFY arm... and flies away.\n");
            Messages.Add("You probably thought Trogdor would be killed...of course Trogdor can not die.. he is Trogdor! \n");
            Messages.Add(@"
            
     )   )                    (       )   ________ 
  ( /(( /(          (  (      )\ ) ( /(  |   /   / 
  )\())\())    (    )\))(   '(()/( )\()) |  /|  /  
 ((_)((_)\     )\  ((_)()\ )  /(_)|(_)\  | / | /   
__ ((_)((_) _ ((_) _(())\_)()(_))  _((_) |/  |/    
\ \ / / _ \| | | | \ \((_)/ /|_ _|| \| |(   (      
 \ V / (_) | |_| |  \ \/\/ /  | | | .` |)\  )\     
  |_| \___/ \___/    \_/\_/  |___||_|\_((_)((_)    
                                                   

            ");
            Messages.Add("Not very original or great, or fun in any way...Oh well.. \n");
            Messages.Add("Type q to quit, or r to restart. \n");
          }
        }
      }
      else Messages.Add("Your inventory is empty. \n"); //message if inventory is empty
    }
  }
}
