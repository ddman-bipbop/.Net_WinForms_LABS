using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmployees
{
    [Serializable]
    public class TypeWork : IValidatable
    {

        /// <summary>
        /// Вид работы
        /// </summary>
        public WorkInfo WorkInfo { get; set; } = new WorkInfo();

        /// <summary>
        /// Оплата за день
        /// </summary>
        public decimal PayByDay { get; set; } = 100;


        public bool IsValid
        {
            get
            {
                if (PayByDay <= 0) return false;
                if (WorkInfo == null) return false;
                return true;
            }
        }

        public TypeWork()
        {

        }

        public TypeWork(WorkInfo workInfo, decimal payByDay)
        {
            WorkInfo = workInfo;
            PayByDay = payByDay;
        }

        public override string ToString()
        {
            return
                $"Работа: {WorkInfo}\r\n Оплата за день: {PayByDay}\r\n";
        }
    }
}


     
