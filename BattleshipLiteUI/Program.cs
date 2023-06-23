using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using System.Collections.Concurrent;

namespace BattleshipLiteUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Print welcome message and instructions
            UIOutput.WelcomeMessage();

            //Instantiate Player One object, Get name and ship locations and store in object. 
            PlayerInfoModel playerOne = new PlayerInfoModel();
            playerOne.Name = PlayerMethods.GetPlayerName(1);
            playerOne.ShipLocations = BattleshipLogic.PlaceBattleShip(PlayerMethods.GetUserShipPlacements());
            
            //Clear the console to ensure player cannot see opponent ship positions
            Console.Clear();

            //Instantiate Player One object, Get name and ship locations and store in object.
            PlayerInfoModel playerTwo = new PlayerInfoModel();
            playerTwo.Name = PlayerMethods.GetPlayerName(2);
            playerTwo.ShipLocations = BattleshipLogic.PlaceBattleShip(PlayerMethods.GetUserShipPlacements());

            Console.Clear();

            //Start to shoot until there is a winner

            bool isGameOver = false;

            do
            {
                //player 1 - build grid display and receive shot information
                GridDisplay.BuildGridDisplay(playerOne.ShotGrid,playerOne, playerTwo);

                Console.WriteLine();

                var playerOneShot = PlayerMethods.GetUserShot(playerOne);
                 
                var playerOneShotOutcome = BattleshipLogic.ShootAtOpponent(playerTwo.ShipLocations, playerOneShot, playerOne.ShotGrid);

                //print hit or miss message, and update player objects based on shot outcome
                UIOutput.HitOrMissMessage(playerOneShotOutcome.shotIsHit);
                playerOne.ShotGrid = playerOneShotOutcome.shots;
                playerTwo.ShipLocations = playerOneShotOutcome.ships;

                //check if the game is over
                if(BattleshipLogic.IsGameOver(playerTwo.ShipLocations))
                {
                    isGameOver = true;
                    break;
                }

                Console.Clear();

                //player 1 - build grid display and receive shot information
                GridDisplay.BuildGridDisplay(playerTwo.ShotGrid, playerTwo,playerOne);

                Console.WriteLine();

                var playerTwoShot = PlayerMethods.GetUserShot(playerTwo);

                var playerTwoShotOutcome = BattleshipLogic.ShootAtOpponent(playerOne.ShipLocations, playerTwoShot, playerTwo.ShotGrid);

                //print hit or miss message, and update player objects based on shot outcome
                UIOutput.HitOrMissMessage(playerTwoShotOutcome.shotIsHit);
                playerTwo.ShotGrid = playerTwoShotOutcome.shots;
                playerOne.ShipLocations = playerTwoShotOutcome.ships;

                //check if the game is over
                if (BattleshipLogic.IsGameOver(playerOne.ShipLocations))
                {
                    isGameOver = true;
                    break;
                }

                Console.Clear();

            } while (!isGameOver);

            //Calculate winner based on remaining number of ships. 
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