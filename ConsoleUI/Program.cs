using BattleshipLibrary;
using BattleshipLibrary.Models;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIOutput.WelcomeMessage();

            //Get player one name and ship locations
            PlayerInfoModel playerOne = new PlayerInfoModel();
            playerOne.Name = PlayerMethods.GetPlayerName(1);
            playerOne.ShipLocations = BattleshipLogic.PlaceBattleShip(PlayerMethods.GetUserShipPlacements());
              
            Console.Clear();

            //Get player two name and ship locations
            PlayerInfoModel playerTwo = new PlayerInfoModel();
            playerTwo.Name = PlayerMethods.GetPlayerName(2);
            playerTwo.ShipLocations = BattleshipLogic.PlaceBattleShip(PlayerMethods.GetUserShipPlacements());

            Console.Clear();

            //Start to shoot until there is a winner

            bool isGameOver = false;

            do
            {
                //player 1
                GridDisplay.BuildGridDisplay(playerOne.ShotGrid,playerOne, playerTwo);

                Console.WriteLine();

                var playerOneShot = PlayerMethods.GetUserShot(playerOne);
                 
                var playerOneShotOutcome = BattleshipLogic.ShootAtOpponent(playerTwo.ShipLocations, playerOneShot, playerOne.ShotGrid);

                UIOutput.HitOrMissMessage(playerOneShotOutcome.shotIsHit);
                playerOne.ShotGrid = playerOneShotOutcome.shots;
                playerTwo.ShipLocations = playerOneShotOutcome.ships;

                if(BattleshipLogic.IsGameOver(playerTwo.ShipLocations))
                {
                    isGameOver = true;
                    break;
                }

                Console.Clear();

                //player 2
                GridDisplay.BuildGridDisplay(playerTwo.ShotGrid, playerTwo,playerOne);

                Console.WriteLine();

                var playerTwoShot = PlayerMethods.GetUserShot(playerTwo);

                var playerTwoShotOutcome = BattleshipLogic.ShootAtOpponent(playerOne.ShipLocations, playerTwoShot, playerTwo.ShotGrid);

                UIOutput.HitOrMissMessage(playerTwoShotOutcome.shotIsHit);
                playerTwo.ShotGrid = playerTwoShotOutcome.shots;
                playerOne.ShipLocations = playerTwoShotOutcome.ships;

                if (BattleshipLogic.IsGameOver(playerOne.ShipLocations))
                {
                    isGameOver = true;
                    break;
                }

                Console.Clear();

            } while (!isGameOver);

            if (playerOne.RemainingShips > playerTwo.RemainingShips) 
            {
                Console.WriteLine($"\n{playerOne.Name} wins!");
            }
            else 
            {
                Console.WriteLine($"\n{playerTwo.Name} wins!");
            }

            Console.ReadLine();

        }
    }
}