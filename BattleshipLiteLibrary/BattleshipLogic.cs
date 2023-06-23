using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleshipLiteLibrary
{
    public class BattleshipLogic
    {
        /// <summary>
        /// This method takes the user position input, and places the ship in a list of GridSpotModel objects. 
        /// The list of the players' ships can be added to the PlayerInfoModel.
        /// </summary>
        /// <param name="userInputShipPositions"></param>
        /// <returns></returns>
        public static List<GridSpotModel> PlaceBattleShip(List<string> userInputShipPositions)
        {
            List<GridSpotModel> shipPositions = new List<GridSpotModel>();

            foreach (string shipPosition in userInputShipPositions)
            {
                shipPositions.Add(GridSpotModel.ConvertInputStringToGridSpot(shipPosition, GridSpotStatus.Ship));
            }

            return shipPositions;
        }

        /// <summary>
        /// Verify if the game is over, and if all of a users ships have been sunk.
        /// </summary>
        /// <param name="playerShips"></param>
        /// <returns></returns>
        public static bool IsGameOver (List<GridSpotModel> playerShips) 
        {
        
            foreach (var ship in playerShips)
            {
                if (ship.Status == GridSpotStatus.Ship) 
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Takes the shot input, and determines if it was a hit ot a miss. 
        /// Updates the appropriate list of ships with the correct GridSpotStatus.
        /// </summary>
        /// <param name="ships"></param>
        /// <param name="shot"></param>
        /// <param name="shots"></param>
        /// <returns></returns>
        public static (List<GridSpotModel> ships, List<GridSpotModel> shots, bool shotIsHit) ShootAtOpponent (List<GridSpotModel> ships, GridSpotModel shot, List<GridSpotModel> shots) 
        {
            if (shots == null)
            {
                shots = new List<GridSpotModel>();
            }

            bool shotIsHit = false;

            foreach (GridSpotModel ship in ships)
            {
                //Check if the shot is a hit and update the GridSpotStatus
                if (ship.Status == GridSpotStatus.Ship && ship.SpotLetter == shot.SpotLetter && ship.SpotNumber == shot.SpotNumber) 
                {
                    ship.Status = GridSpotStatus.Hit;
                    shot.Status = GridSpotStatus.Hit;
                    shotIsHit = true;
                }

                //If the shot did not hit, mark as a miss
                if (!shotIsHit)
                {
                    shot.Status = GridSpotStatus.Miss;
                }
            }

            //Add the shot to the shot list after determining if it was a hit or miss
            shots.Add(shot);

            return (ships, shots, shotIsHit);
        }

        /// <summary>
        /// Checks whether the shot has already been made, and ensures the player cannot submit a duplicate shot. 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="shotAsGridSpot"></param>
        /// <returns></returns>
        public static bool ShotAlreadyExists (PlayerInfoModel player, GridSpotModel shotAsGridSpot)
        {
            if (player == null || player.ShotGrid == null || shotAsGridSpot == null)
            {
                return false;
            }

            try
            {
                foreach (var shot in player.ShotGrid)
                {
                    if (shot.SpotLetter == shotAsGridSpot.SpotLetter && shot.SpotNumber == shotAsGridSpot.SpotNumber && shotAsGridSpot.Status == GridSpotStatus.Shot)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
