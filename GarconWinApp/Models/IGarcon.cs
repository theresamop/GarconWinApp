using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public interface IGarcon
    {
        public int Id { get; set; }
        public string DisplayMember { get; }

     
    }
}
