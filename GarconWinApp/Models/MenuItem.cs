using GarconWinApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public class MenuItem: IGarcon
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DisplayMember
        {
            get { return string.Format("{0} {1} : {2} - ({3}) {4} min. cook time", IsChefRecommendation ? "*" : "", MenuItemType.ToString(), Name, GetItemPriceWTax(ItemPrice).ToString("0.00"), PrepTimeInMinutes); }

        }

        private MenuType _menuItemType = MenuType.MAINCOURSE;
      //  private decimal _itemTax = 10;
        private decimal _itemPrice;
        private int _prepTimeInMinutes = 0;

        private bool _isAvailability = false;

        private bool isChefRecommendation = true;
        public MenuType MenuItemType { get => _menuItemType; set => _menuItemType = value; }
        public decimal ItemPrice { get => _itemPrice; set => _itemPrice = value; }
      //  public decimal ItemTax { get => _itemTax; set => _itemTax = value; }
        public int PrepTimeInMinutes { get => _prepTimeInMinutes; set => _prepTimeInMinutes = value; }
        public bool IsAvailability { get => _isAvailability; set => _isAvailability = value; }
        public bool IsChefRecommendation { get => isChefRecommendation; set => isChefRecommendation = value; }

        public decimal GetItemPriceWTax(decimal price)
        {
            return (price + ((price * ApplicationSettings.InclusiveTax) / 100));
        }
    }
    
}
