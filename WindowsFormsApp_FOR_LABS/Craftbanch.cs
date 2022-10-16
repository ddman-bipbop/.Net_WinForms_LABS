using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Craftbanch
    {
        /// <summary>
        /// Страна
        /// </summary>
        public string State { get; set; } = "Bryansk";
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Today;
        /// <summary>
        /// Марка станка
        /// </summary>
        public string Mark { get; set; } = "Mark 2";

        public override string ToString()
        {
            return $"Страна: {State}\r\nДата: {Date}\r\nМарка:{Mark}\r\n";
        }

    }
}
