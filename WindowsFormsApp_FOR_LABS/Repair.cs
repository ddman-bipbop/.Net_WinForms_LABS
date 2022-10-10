using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Repair
    {
        Stanok nameStanok_ { get; set; } = new Stanok();
        NameRepair nameRepair_ { get; set; } = new NameRepair();
        public DateTime dateStart_ { get; set; } = DateTime.Now;

        public string commet_ { get; set; } = "No comments";
    }
}
