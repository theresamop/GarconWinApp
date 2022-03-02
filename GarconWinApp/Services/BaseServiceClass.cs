using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Services
{
    public abstract class BaseServiceClass<T>
    {
        
        public abstract void AddItem(T item);
        public abstract void RemoveItem(int Id);
        public abstract T? GetItem(int Id);
        public abstract List<T> GetItems();
      
        public abstract void Validate();
    }
}
