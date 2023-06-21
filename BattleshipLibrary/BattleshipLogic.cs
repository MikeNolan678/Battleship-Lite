using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleshipLibrary
{
    public class BattleshipLogic
    {
        public static List<GridSpotModel> PlaceBattleShip(List<string> userInputShipPositions)
        {
            List<GridSpotModel> shipPositions = new List<GridSpotModel>();

            foreach (string shipPosition in userInputShipPositions)
            {
                shipPositions.Add(GridSpotModel.ConvertInputStringToGridSpot(shipPosition, GridSpotStatus.Ship));
            }

            return shipPositions;
        }

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

        public static (List<GridSpotModel> ships, List<GridSpotModel> shots, bool shotIsHit) ShootAtOpponent (List<GridSpotModel> ships, GridSpotModel shot, List<GridSpotModel> shots) 
        {
            if (shots == null)
            {
                shots = new List<GridSpotModel>();
            }

            bool shotIsHit = false;

            foreach (GridSpotModel ship in ships)
            {
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
