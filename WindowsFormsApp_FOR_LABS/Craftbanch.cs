using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Craftbanch
    {
        /// <summary>
        /// Уникальный идентификатор нового клиента (аналог автоинкремента)
        /// </summary>
        private static int _newCraftbanchId;

        private static int NewCraftbanchId
        {
            get
            {
                _newCraftbanchId++;
                return _newCraftbanchId;
            }
        }
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public int CraftbanchId { get; }

        public Craftbanch() 
        {
            CraftbanchId = NewCraftbanchId;
        }
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
            return $"Страна: {State}\r\n Дата: {Date}\r\n Марка:{Mark}\r\n";
        }

    }
}
