using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class UIOutput
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Battleships - Lite");
            Console.WriteLine("------------------------------------------------------------------------\n");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter your name.");
            Console.WriteLine("2. Place your 5x ships - You must enter a co-ordinate between A1 - E5.");
            Console.WriteLine("3. Repeat for player 2.");
            Console.WriteLine("4. Take turns to shoot, and attempt to hit the other players ships.");
            Console.WriteLine("5. The first person to destroy all of their opponent's ships wins!\n");
            Console.WriteLine("------------------------------------------------------------------------\n");
        }


        public static void HitOrMissMessage(bool shotIsHit)
        {
            if (shotIsHit)
            {
                Console.WriteLine("\nHit!\n");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("\nMiss!\n");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }
    }
}
