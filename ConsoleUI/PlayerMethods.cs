using BattleshipLibrary;
using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Models;

namespace ConsoleUI
{
    public class PlayerMethods
    {
        //Asks the user for their name.
        public static string GetPlayerName(int PlayerNumber)
        {
            Console.Write($"Enter player {PlayerNumber} name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Asks the user for the placement of their ships. The list is converted to an object using methods in the GridSpotModel class
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUserShipPlacements()
        {
            List<string> userInputShipPositions = new List<string>();
            
            int count = 1;

            //The user will enter 5x ship placements
            while (count <= 5)
            {
                Console.Write($"Enter ship {count} position (eg. A{count}): ");
                string shipPosition = Console.ReadLine();

                try
                {
                    if (GridSpotModel.InputStringIsValidPosition(shipPosition.ToLower()))
                    {
                        userInputShipPositions.Add(shipPosition.ToLower());
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Ship Position");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Ship Position");
                }
            }

            return userInputShipPositions;
        }
        /// <summary>
        /// Gets the shot position from the user, and converts to GridSpotModel object. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static GridSpotModel GetUserShot(PlayerInfoModel player)
        {
            bool isValidShot;

            GridSpotModel shotAsGridSpot = new GridSpotModel();

            Console.Write($"Enter shot position (eg. A1): ");
            string shotPosition = Console.ReadLine();

            do
            {
                try
                {
                    isValidShot = GridSpotModel.InputStringIsValidPosition(shotPosition.ToLower());
                    shotAsGridSpot = GridSpotModel.ConvertInputStringToGridSpot(shotPosition, GridSpotStatus.Shot);

                    if (BattleshipLogic.ShotAlreadyExists(player, shotAsGridSpot)) 
                    {
                        throw new Exception("You have already made this shot!");
                    }
                }
                catch (Exception e)
                {
                    Console.Write($"Invalid Shot - {e.Message}. Try Again: ");
                    shotPosition = Console.ReadLine();
                    isValidShot = false;
                }
                
            } while (!isValidShot);
               
            return shotAsGridSpot;
        }

        /// <summary>
        /// Calculates the number of ships that are remaining (ie. haven't been hit). 
        /// This is used to display a score in the UI.
        /// </summary>
        /// <param name="ships"></param>
        /// <returns></returns>
        public static int RemainingShips (List<GridSpotModel> ships)
        {
            int count = 0;

            foreach (GridSpotModel ship in ships)
            {
                if (ship.Status == GridSpotStatus.Ship)
                {
                    count++;
                }
            }

            return count;
        }
    }
}