using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Repair
    {
        /// <summary>
        /// Название станка
        /// </summary>
        Craftbanch nameStanok_ { get; set; } = new Craftbanch();
        /// <summary>
        /// Вид ремонта
        /// </summary>
        NameRepair nameRepair_ { get; set; } = new NameRepair();
        /// <summary>
        /// Дата начала ремонта
        /// </summary>
        public DateTime dateStart_ { get; set; } = DateTime.Now;
        /// <summary>
        /// Примечание
        /// </summary>
        public string commet_ { get; set; } = "No comments";
   
    }
}
