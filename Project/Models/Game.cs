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
      IRoom Room0 = new Room("Cave Enterance", "You are at the front of the cave... where else would you be <grumble>", false, false);
      IRoom Room1 = new Room("some kinda hallway \n", "it has walls and stuff..you know dungeony looking.. maybe with some kinda... bats and stuff \n", false, false);
      IRoom Room2 = new Room("Another Hallway!?!? \n", "it looks kind of like the last hallway.. not very original I would say..who wrote this?? \n At least there one other door you could choose.. if you dare... \n", false, false);
      IRoom Death = new Room("The Room of Doooom!! \n", "This room is filled with Trogdor's mighty burninating flame!! \n", false, true);
      IRoom Room3 = new Room("Oh look another dungeony hallway \n", "wow more bats... and is THAT a spider... how original... \n", false, false);
      IRoom Trogdor = new Room("Trogdor's Lair \n", "You have entered the lair of the mighty Trogdor! Behold his majesticness.. and his big BEEFY arm \n Trogdor is busy burning the peoples.. and their thatch-roof cottages!!! \n", true, false);

      //Connecting Rooms
      Room0.AddExits("east", Room1);

      Room1.AddExits("west", Room0);
      Room1.AddExits("east", Room2);

      Room2.AddExits("east", Room3);
      Room2.AddExits("west", Room1);
      Room2.AddExits("south", Death);

      Room3.AddExits("west", Room2);
      Room3.AddExits("north", Trogdor);

      Trogdor.AddExits("south", Room3);

      //Add items
      Item Item1 = new Item("nunchuckgun", "Hmm..this is a most potent weapon..umm yeah");
      Item Item2 = new Item("grumblecakes", "a delicious treat full of grumbly goodness...");

      //Item locations
      Room0.Items.Add(Item1);
      Room3.Items.Add(Item2);

      CurrentRoom = Room0;
    }

    public Game()
    {
      CurrentPlayer = new Player();
      GetTemplate();
      Setup();
    }

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
               
                Survive Trogdor's Lair of Doooom! and stuff...

                                                                          
                      ..,                   ,;,                            
                       i;.                    .;                           
                       ;  ,;:.               ,;,;                          
       ,i::           .;..:;,:               :::,                          
   .,;;, ;            ,..  :;,         ;       ;                           
    ,:    ,,         ,, .:i        ,  :.      .;                           
      ::.  .;.      ,:;.           .: ;                                    
        .;.; .i.  ,;;;::::;;;:.    ;,1.1   ,;,                             
          ,:::;:;.              .;;::;;:;;;;;:,                            
              ;.                              ;      .:;:..;,     ....     
       ,;;;;                        :,....   ,; .::..;;..;;:,.     ,;.     
    ,;.       ;          :    .;;.   :1:;,;:,;  .;:..i:::,.     ::         
   .:       .: ;.        .:       ,;,  .,;11:        ,i,.             .;;: 
   ,,       i.  ;;        .;          :;::,,;  ,:::..1;:i:       .;;,      
    ;   .,,   .;. .;.  ,,:;..;.                  :.  :;i        .::::;;,   
   ;.    :;;::       .;:. .i,;:,;.                .;            ,::;:;;:,  
   .;, ;   .;             :;.     .;,               :.         .;;,        
    .;. :;, ,:               .;.     .;.             .: ..  ;1;,.   .;;.   
       ::   ,,.                 ,:      ;.             :.:,;, ,;.   .,::,  
         .i .,if.                 ;      :,             .i;. .::.:,        
          :.   .i                 :       ;               .;     .:.       
           .,,.                   ;       :                                
                            ,,   .:      .:                                
                         .  .:  ,i       ;                                 
                     :,  ;:  .:,:      ,:                                  
                ;i.  :,, ; :,,;      ,:                                    
                  :;;i::;;;:.     .;,                                      
                     .:,:,...:;;;.                                         
                         ,.   ;                                            
                         ;    ;                                            
                         ;    ;                                            
                        .,    :;:.                                         
                        :.                                                 
                                                                    
Welcome weary type traveller, you have entered Trogdor's lair... 

  ");
    }
  }
}