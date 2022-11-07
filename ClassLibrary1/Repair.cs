using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_FOR_LABS
{
    public class Repair
    {
        /// <summary>
        /// Уникальный идентификатор нового клиента (аналог автоинкремента)
        /// </summary>
        private static int _newRepairId;

        private static int NewRepairId
        {
            get
            {
                _newRepairId++;
                return _newRepairId;
            }
        }
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public int RepairId { get; }

        public Repair()
        {
            RepairId = NewRepairId;
        }
        /// <summary>
        /// Название станка
        /// </summary>
        public Craftbanch NameStanok { get; set; } = new Craftbanch();
        /// <summary>
        /// Вид ремонта
        /// </summary>
        public NameRepair NameRepair { get; set; } = new NameRepair();
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
            return $"{NameStanok.Mark}\r\n {NameRepair.Name}\r\n {DateStart}\r\n {Commet} ";
        }
    }
}
