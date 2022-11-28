using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmployees
{
    [Serializable]
    public class WorkInfo
    {
        /// <summary>
        /// Название работы
        /// </summary>
        public string NameWork { get; set; } = "";

        /// <summary>
        /// Информация о работе
        /// </summary>
        public string Info { get; set; } = "";

        /// <summary>
        /// Время в часах на выполнения
        /// </summary>
        public int Time { get; set; } = 1;

        public override string ToString()
        {
            return $"Название: {NameWork}\r\n Задача: {Info}\r\n Время на выполнение: {Time}\r\n";
        }
    }
}
