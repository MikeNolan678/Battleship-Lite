﻿using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class GridDisplay
    {
        public static void BuildGridDisplay(List<GridSpotModel> shotGrid, PlayerInfoModel player, PlayerInfoModel opponent)
        {

            player.RemainingShips = PlayerMethods.RemainingShips(player.ShipLocations);
            opponent.RemainingShips = PlayerMethods.RemainingShips(opponent.ShipLocations);

            Console.WriteLine($"{player.Name}'s turn... \n");
            Console.WriteLine("Hit = H");
            Console.WriteLine("Miss = M");
            Console.WriteLine();
            Console.WriteLine($"Your ships remaining: {player.RemainingShips}");
            Console.WriteLine($"Opponent's ships remaining: {opponent.RemainingShips}");
            Console.WriteLine();


            for (int i = 65; i < 70; i++) // 65 is ASCII for 'A', 70 is 'E'
            {
                for (int j = 1; j < 6; j++)
                {
                    bool spotPrinted = false;

                    if (shotGrid != null)
                    {
                        foreach (GridSpotModel gridSpot in shotGrid)
                        {
                            if (((char)i).ToString().ToLower() == gridSpot.SpotLetter && gridSpot.SpotNumber == j)
                            {
                                if (gridSpot.Status == GridSpotStatus.Hit)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(" H ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    spotPrinted = true;
                                }
                                else if (gridSpot.Status == GridSpotStatus.Miss)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write(" M ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    spotPrinted = true;
                                }
                                else
                                {
                                    throw new Exception("Error building GridDisplay.");
                                }
                            }
                        }
                    }
                     if (!spotPrinted)
                    {
                        Console.Write($"{(char)i}{j} "); // Convert i to a character}
                    }


                }
                Console.WriteLine();
            }
        }
    }
}
