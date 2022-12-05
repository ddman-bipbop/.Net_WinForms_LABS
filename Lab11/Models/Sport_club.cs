using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Models
{
    public class Sport_club
    {
        public int IdClub { get; set; }
        public int IdKind { get; set; }
        public string NameClub { get; set; }
        public string TextClub { get; set; }
        public DateTime CreateDateClub { get; set; }
    }
}
