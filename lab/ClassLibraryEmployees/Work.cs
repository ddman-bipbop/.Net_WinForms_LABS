using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmployees
{
    [Serializable]
    public class Work : IValidatable
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employees Employees { get; set; }
        /// <summary>
        /// Тип работы
        /// </summary>
        public TypeWork TypeWork { get; set; }
        /// <summary>
        /// Дата начала 
        /// </summary>
        public DateTime StartDate { get; set; } = new DateTime(2002, 1, 1);
        /// <summary>
        /// Дата окончания 
        /// </summary>
        public DateTime EndDate { get; set; } = new DateTime(2002, 1, 2);

        public bool IsValid
        {
            get
            {
                if (Employees == null) return false;
                if (TypeWork == null) return false;
                if (EndDate <= StartDate) return false;
                return true;
            }
        }

        public Work()
        {}

        public Work(Employees employees, TypeWork typeWork, DateTime startDate, DateTime endDate)
        {
            Employees = employees;
            TypeWork  = typeWork;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"Сотрудник - {Employees}\r\n Тип работы - {TypeWork}\r\n Начало-конец: {StartDate}-{EndDate}\r\n";
        }
    }
}


