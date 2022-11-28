using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmployees.Serialization
{

    [Serializable]
    public class WorkSerializable
    {
        public string TypeWorkId { get; set; }
        public int EmployeesId { get; set; }
        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата окончания работы
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
