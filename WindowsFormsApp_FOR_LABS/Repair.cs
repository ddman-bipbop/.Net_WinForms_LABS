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
        Craftbanch NameStanok { get; set; } = new Craftbanch();
        /// <summary>
        /// Вид ремонта
        /// </summary>
        NameRepair NameRepair { get; set; } = new NameRepair();
        /// <summary>
        /// Дата начала ремонта
        /// </summary>
        public DateTime DateStart { get; set; } = DateTime.Now;
        /// <summary>
        /// Примечание
        /// </summary>
        public string Commet { get; set; } = "No comments";

        public override string ToString()
        {
            return $"Название станка: {NameStanok}\r\nВид ремонта: {NameRepair}\r\nДата начала: {DateStart}\r\nПримечание: {Commet} ";
        }
    }
}
