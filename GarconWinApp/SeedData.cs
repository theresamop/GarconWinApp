using GarconWinApp.Enums;
using GarconWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp
{
    public class SeedData
    {
        #region "Main Course"

        public static readonly MenuItem MC1 = new MenuItem()
        {
            Id = 1,
            Description = "Meat Dish (beef) with peanut sauce",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 200,
            MenuItemType = MenuType.MAINCOURSE,
            Name = "Beef Kare Kare",
            PrepTimeInMinutes = 3
        };

        public static readonly MenuItem MC2 = new MenuItem()
        {
            Id = 2,
            Description = "Soup Dish",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 270,
            MenuItemType = MenuType.MAINCOURSE,
            Name = "Pork Sinigang",
            PrepTimeInMinutes = 3
        };

        public static readonly MenuItem MC3 = new MenuItem()
        {
            Id = 3,
            Description = "Soup dish",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 300,
            MenuItemType = MenuType.MAINCOURSE,
            Name = "Beef Bulalo",
            PrepTimeInMinutes = 1
        };

        #endregion

        #region "Appetizer"


        public static readonly MenuItem AP1 = new MenuItem()
        {
            Id = 4,
            Description = "Fried Potatos",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 100,
            MenuItemType = MenuType.APPETIZER,
            Name = "French Fries",
            PrepTimeInMinutes = 1
        };

        public static readonly MenuItem AP2 = new MenuItem()
        {
            Id = 5,
            Description = "Nacho with beef, salsa and cheese",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 277.90m,
            MenuItemType = MenuType.APPETIZER,
            Name = "Beef Nachos",
            PrepTimeInMinutes = 3
        };

        public static readonly MenuItem AP3 = new MenuItem()
        {
            Id = 6,
            Description = "Fried squid rings",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 300.50m,
            MenuItemType = MenuType.APPETIZER,
            Name = "Calamares",
            PrepTimeInMinutes = 3
        };

        #endregion

        #region "Drinks"


        public static readonly MenuItem DR1 = new MenuItem()
        {
            Id = 7,
            Description = "with sago and gulaman",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 50,
            MenuItemType = MenuType.DRINKS,
            Name = "Sago't Gulaman",
            PrepTimeInMinutes = 5
        };

        public static readonly MenuItem DR2 = new MenuItem()
        {
            Id = 8,
            Description = "Carbonated drink",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 50,
            MenuItemType = MenuType.DRINKS,
            Name = "SoftDrinks",
            PrepTimeInMinutes = 3
        };

        public static readonly MenuItem DR3 = new MenuItem()
        {
            Id = 9,
            Description = "House blend iced tea",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 60,
            MenuItemType = MenuType.DRINKS,
            Name = "Iced Tea",
            PrepTimeInMinutes = 3
        };

        #endregion

        #region "Desserts"


        public static readonly MenuItem DS1 = new MenuItem()
        {
            Id = 10,
            Description = "Cheese cake",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 150,
            MenuItemType = MenuType.DESSERT,
            Name = "New York Cheese Cake",
            PrepTimeInMinutes = 3
        };

        public static readonly MenuItem DS2 = new MenuItem()
        {
            Id = 11,
            Description = "Sweet flan made of milk and egg",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 120,
            MenuItemType = MenuType.DESSERT,
            Name = "Leche Flan",
            PrepTimeInMinutes = 3
        };

        public static readonly MenuItem DS3 = new MenuItem()
        {
            Id = 12,
            Description = "Sweet blend of diffent ingredients",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 160,
            MenuItemType = MenuType.DESSERT,
            Name = "Halo Halo",
            PrepTimeInMinutes = 3
        };

        #endregion


        public static List<MenuItem> PopulateMenu(List<MenuItem> menuitems)
        {

           
            //Main Courses
            menuitems.Add(MC1);
            menuitems.Add(MC2);
            menuitems.Add(MC3);

            //Appetizers
            menuitems.Add(AP1);
            menuitems.Add(AP2);
            menuitems.Add(AP3);

            //Drinks
            menuitems.Add(DR1);
            menuitems.Add(DR2);
            menuitems.Add(DR3);

            //Dessert
            menuitems.Add(DS1);
            menuitems.Add(DS2);
            menuitems.Add(DS3);

           

            return menuitems;
        }
        public static List<MenuItem> PopulateMenu()
        {
            List<MenuItem> menuitems = new List<MenuItem>();

            //Main Courses
            menuitems.Add(MC1);
            menuitems.Add(MC2);
            menuitems.Add(MC3);

            //Appetizers
            menuitems.Add(AP1);
            menuitems.Add(AP2);
            menuitems.Add(AP3);

            //Drinks
            menuitems.Add(DR1);
            menuitems.Add(DR2);
            menuitems.Add(DR3);

            //Dessert
            menuitems.Add(DS1);
            menuitems.Add(DS2);
            menuitems.Add(DS3);

           
            return menuitems;
        }
    }
}
