using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Workshop
    {
        /// <summary>
        /// Словарь станков
        /// </summary>
        public static Dictionary<int, Craftbanch> DCraftbanch { get; } = new Dictionary<int, Craftbanch>();

        /// <summary>
        /// Словарь видов ремонта
        /// </summary>
        public static Dictionary<int, NameRepair> DNameRepair { get; } = new Dictionary<int, NameRepair>();

        /// <summary>
        /// Словарь ремонтов
        /// </summary>
        public static Dictionary<int, Repair> DRepair { get; } = new Dictionary<int, Repair>();
    }
}
