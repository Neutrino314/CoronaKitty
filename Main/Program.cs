using System;
using System.Collections.Generic;
using CoronaKitty;

namespace Main
{
    class Program
    {

        static void Main(string[] args)
        {
        
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            CoronaKitty.World.Doorway door = new CoronaKitty.World.Doorway(false, "");

            CoronaKitty.World.Room sideRoom = new CoronaKitty.World.Room("As you enter through the doorway you notice the rows of oak casks lining the walls. It appears to be some sort of storage room. You may be trapped...");

            CoronaKitty.World.Room entranceHall = new CoronaKitty.World.Room("You are standing in a grand entrance hall.\nMagnificent paintings depicting feats of heroes in bygone ages line the walls, separated only by glowing torches and mighty stone pillars. In front of you there is a massive oak and wrought iron door which seems to be locked from the inside. To your right however is a far smaller door leading god knows where...");

            entranceHall.AddAdjacent(sideRoom, door, "EAST");

            Application app = new Application(entranceHall);

            app.Run();

            Console.ReadLine();

            Console.ResetColor();
            Console.Clear();

        }
    }
}
