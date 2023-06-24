using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Object used to clasify both the position and status of that position.
namespace BattleshipLiteLibrary.Models
{
    public class GridSpotModel
    {
        private string spotLetter;

        public string SpotLetter
        {
            get
            {
                return spotLetter;
            }
            set
            {
                //Validates that the letter is within the expected range of the grid.
                if (value == "a" ||
                    value == "b" ||
                    value == "c" ||
                    value == "d" ||
                    value == "e")
                {
                    spotLetter = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Spot Letter value must be between A - E");
                }

            }
        }


        public int SpotNumber { get; set; }
        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;

        //Converts string input from the user into the GridSpotModel object
        public static GridSpotModel ConvertInputStringToGridSpot(string position, GridSpotStatus GridSpotStatus)
        {
            GridSpotModel gridSpot = new GridSpotModel();

            gridSpot.SpotLetter = position.Substring(0, 1).ToLower();
            gridSpot.Status = GridSpotStatus;

            bool isValidSpotNumber = int.TryParse(position.Substring(1, 1), out int spotNumberAsInt);

            if (isValidSpotNumber)
            {
                gridSpot.SpotNumber = spotNumberAsInt;
            }
            else
            {
                throw new IndexOutOfRangeException("Number is out of range (1-5)");
            }

            return gridSpot;
        }

        //Verifies that the position input by the user (as a string) is a valid position on the grid, and is in the correct format (XY)
        public static bool InputStringIsValidPosition(string position)
        {

            if (position.Length != 2)
            {
                throw new IndexOutOfRangeException("Position must be format: XY");
            }

            if (position.Substring(0,1).ToLower() == "a" ||
                        position.Substring(0, 1).ToLower() == "b" ||
                        position.Substring(0, 1).ToLower() == "c" ||
                        position.Substring(0, 1).ToLower() == "d" ||
                        position.Substring(0, 1).ToLower() == "e")
            {
                if (position.Substring(1, 1) == "1" ||
                        position.Substring(1, 1) == "2" ||
                        position.Substring(1, 1) == "3" ||
                        position.Substring(1, 1) == "4" ||
                        position.Substring(1, 1) == "5")
                {
                    return true;
                }

                throw new IndexOutOfRangeException("Position must be between A1 - E5");
                return false;
            }
            else
            {
                throw new IndexOutOfRangeException("Position must be between A1 - E5");
                return false;
            }

        }
    }
}

