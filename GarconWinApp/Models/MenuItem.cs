using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        public string? Name { get; set; } = null;

        public string? Description { get; set; } =  string.Empty;

        public MenuType MenuItemType { get; set; } = MenuType.MAINCOURSE;

        public decimal ItemPrice { get; set; } = decimal.Zero;

        public int prepTimeInMinutes { get; set; } = 0;

        public bool IsAvailability { get; set; } = false;

        public bool IsChefRecommendation { get; set ; } = true;

        public enum MenuType
        {
            APPETIZER,
            MAINCOURSE,
            DESSERT,
            DRINKS,
            OTHERMENU

        }

        public string Recommended
        { 
            get { return IsChefRecommendation ? "*" : ""; }
        
        }

        public string DisplayMember
        {
            get { return String.Format("{0} : {1} - ({2}) {3}", MenuItemType.ToString(), Name, ItemPrice.ToString(), IsChefRecommendation ? "*" : ""); }
            
        }

    }
}
