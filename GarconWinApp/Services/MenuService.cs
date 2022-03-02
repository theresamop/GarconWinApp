using GarconWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Services
{
    public class MenuService : BaseServiceClass<MenuItem> 
    {
        public override void AddItem(MenuItem item)
        {
            throw new NotImplementedException();
        }


        public override MenuItem GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public override List<MenuItem> GetItems()
        {
            return SeedData.PopulateMenu();
        }

        public override void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
