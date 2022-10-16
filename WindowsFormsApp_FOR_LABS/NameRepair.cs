using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class NameRepair
    {
        /// <summary>
        /// Уникальный идентификатор нового клиента (аналог автоинкремента)
        /// </summary>
        private static int _newNameRepairId;

        private static int NewNameRepairId
        {
            get
            {
                _newNameRepairId++;
                return _newNameRepairId;
            }
        }
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public int NameRepairId { get; }

        public NameRepair() 
        {
            NameRepairId = NewNameRepairId;
        }
        /// <summary>
        /// Название (вид) ремонта
        /// </summary>
        public CategoryNameRepair Name { get; set; } = CategoryNameRepair.Current;
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
            return $"Название: {Name}\r\n Продолжительность: {Duration}\r\n Цена: {Price}\r\n Примечание: {Commet}\r\n";
        }
    }
}
