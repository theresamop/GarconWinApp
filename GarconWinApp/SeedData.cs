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
            MenuItemId = 1,
            Description = "Meat Dish (beef) with peanut sauce",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 200,
            MenuItemType = MenuItem.MenuType.MAINCOURSE,
            Name = "Beef Kare Kare",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem MC2 = new MenuItem()
        {
            MenuItemId = 2,
            Description = "Soup Dish",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 270,
            MenuItemType = MenuItem.MenuType.MAINCOURSE,
            Name = "Pork Sinigang",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem MC3 = new MenuItem()
        {
            MenuItemId = 3,
            Description = "Soup dish",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 300,
            MenuItemType = MenuItem.MenuType.MAINCOURSE,
            Name = "Beef Bulalo",
            prepTimeInMinutes = 3
        };

        #endregion

        #region "Appetizer"


        public static readonly MenuItem AP1 = new MenuItem()
        {
            MenuItemId = 4,
            Description = "Fried Potatos",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 100,
            MenuItemType = MenuItem.MenuType.APPETIZER,
            Name = "French Fries",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem AP2 = new MenuItem()
        {
            MenuItemId = 5,
            Description = "Nacho with beef, salsa and cheese",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 270,
            MenuItemType = MenuItem.MenuType.APPETIZER,
            Name = "Beef Nachos",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem AP3 = new MenuItem()
        {
            MenuItemId = 6,
            Description = "Fried squid rings",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 300,
            MenuItemType = MenuItem.MenuType.APPETIZER,
            Name = "Calamares",
            prepTimeInMinutes = 3
        };

        #endregion

        #region "Drinks"


        public static readonly MenuItem DR1 = new MenuItem()
        {
            MenuItemId = 7,
            Description = "with sago and gulaman",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 50,
            MenuItemType = MenuItem.MenuType.DRINKS,
            Name = "Sago't Gulaman",
            prepTimeInMinutes = 5
        };

        public static readonly MenuItem DR2 = new MenuItem()
        {
            MenuItemId = 8,
            Description = "Carbonated drink",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 50,
            MenuItemType = MenuItem.MenuType.DRINKS,
            Name = "SoftDrinks",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem DR3 = new MenuItem()
        {
            MenuItemId = 9,
            Description = "House blend iced tea",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 60,
            MenuItemType = MenuItem.MenuType.DRINKS,
            Name = "Iced Tea",
            prepTimeInMinutes = 3
        };

        #endregion

        #region "Desserts"


        public static readonly MenuItem DS1 = new MenuItem()
        {
            MenuItemId = 10,
            Description = "Cheese cake",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 150,
            MenuItemType = MenuItem.MenuType.DESSERT,
            Name = "New York Cheese Cake",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem DS2 = new MenuItem()
        {
            MenuItemId = 11,
            Description = "Sweet flan made of milk and egg",
            IsAvailability = true,
            IsChefRecommendation = false,
            ItemPrice = 120,
            MenuItemType = MenuItem.MenuType.DESSERT,
            Name = "Leche Flan",
            prepTimeInMinutes = 3
        };

        public static readonly MenuItem DS3 = new MenuItem()
        {
            MenuItemId = 12,
            Description = "Sweet blend of diffent ingredients",
            IsAvailability = true,
            IsChefRecommendation = true,
            ItemPrice = 160,
            MenuItemType = MenuItem.MenuType.DESSERT,
            Name = "Halo Halo",
            prepTimeInMinutes = 3
        };

        #endregion


        public static List<MenuItem> PopulateMenu(List<MenuItem> menuitems)
        {

            //foreach (var item in dbContext.OrderItems)
            //{
            //    dbContext.Remove(item);
            //}

            //foreach (var item in dbContext.Orders)
            //{
            //    dbContext.Remove(item);
            //}

            //dbContext.SaveChanges();

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

            //dbContext.OrderItems.Add(OrderItem1);
            //dbContext.Orders.Add(Order1);

            //Order1.OrderItems.Add(OrderItem1);

            //dbContext.SaveChanges();

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
