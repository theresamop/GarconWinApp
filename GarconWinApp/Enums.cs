using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Enums
{
    
    public enum OrderItemStatus
    {
        NEWORDER,
        INPREPARATION,
        READYTOSERVE,
        SERVED,
        CANCELLED

    }
    public enum MenuType
    {
        APPETIZER,
        MAINCOURSE,
        DESSERT,
        DRINKS,
        OTHERMENU

    }

    public enum MessageType
    {
        NoItemChecked,
        NoOrderAdded,
        Eror,
        Successful,
        Done
    }
}
