using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
    //The object assigned to each player, to record their details, including the position of their ships, and of the shots they have placed. 
    public class PlayerInfoModel
    {
        public string Name { get; set; }
        public int RemainingShips { get; set; }
        public List<GridSpotModel> ShipLocations { get; set; }
        public List<GridSpotModel> ShotGrid { get; set; }

    }

    
}
