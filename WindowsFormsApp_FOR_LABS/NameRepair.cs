using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class NameRepair
    {
        /// <summary>
        /// Название (вид) ремонта
        /// </summary>
        public string Name { get; set; } = "midle repair";
        /// <summary>
        /// Продолжительность
        /// </summary>
        public int Duration { get; set; } = 28;
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; } = 228.24;
        /// <summary>
        /// Примечание
        /// </summary>
        public string Commet { get; set; } = "No comments";

        public override string ToString()
        {
            return $"Название: {Name}\r\nПродолжительность: {Duration}\r\nЦена: {Price}\r\nПримечание: {Commet}\r\n";
        }
    }
}
