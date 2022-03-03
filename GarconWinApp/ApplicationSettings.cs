using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp
{
    internal static class ApplicationSettings
    {
        public static decimal InclusiveTax { get; set; } = 12;

        public static decimal ServiceCharge { get; set; } = 5;

        public static string CurrencyFormat { get; set; } = "#,##0.00";
        public static string CurrencySymbol { get; set; } = "P";
    }
}
