using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_FOR_LABS
{
    public class Workshop
    {
        public event EventHandler CraftbanchAdded;
        public event EventHandler NameRepairAdded;
        public event EventHandler RepairAdded;
        public event EventHandler CraftbanchRemoved;
        public event EventHandler NameRepairRemoved;
        public event EventHandler RepairRemoved;


        /// <summary>
        /// Словарь станков
        /// </summary>
        private Dictionary<int, Craftbanch> _craftbanchs = new Dictionary<int, Craftbanch>();

        /// <summary>
        /// Словарь видов ремонта
        /// </summary>
        private Dictionary<int, NameRepair> _nameRepairs = new Dictionary<int, NameRepair>();

        /// <summary>
        /// Список ремонтов
        /// </summary>
        private List<Repair> _repairs = new List<Repair> ();

        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        public IEnumerable<Craftbanch> Craftbanchs
        {
            get { return _craftbanchs.Values.AsEnumerable(); }
        }
        /// <summary>
        /// Коллекция номеров
        /// </summary>
        public IEnumerable<NameRepair> NameRepairs
        {
            get
            {
                return _nameRepairs.Values.AsEnumerable();
            }
        }
        /// <summary>
        /// Коллекция поселений
        /// </summary>
        public IEnumerable<Repair> Repairs
        {
            get
            {
                return _repairs;
            }
        }


        private static Workshop _instance;
        /// <summary>
        /// Единственный экземпляр класса Workshop
        /// </summary>
        public static Workshop Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Workshop();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private Workshop()
        {

        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="client">Информация о клиенте</param>
        public void AddClient(Craftbanch client)
        {
            if (client.Mark == "" || client.State== "")
            {
                throw new InvalidCraftbanchException("Информация о станке заполнена некорректно");
            }
            try
            {
                _craftbanchs.Add(client.CraftbanchId, client);
                //Герерируем событие о том, что клиент добавлен
                CraftbanchAdded?.Invoke(client, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidCraftbanchException("При добавлении станка произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Добавление номера
        /// </summary>
        /// <param name="room">Информация о номере</param>
        public void AddRoom(NameRepair room)
        {
            if (room.Duration==0)
            {
                throw new InvalidNameRepairException("Информация о вида работы заполнена некорректно");
            }
            try
            {
                _nameRepairs.Add(room.NameRepairId, room);
                //Герерируем событие о том, что номер добавлен
                NameRepairAdded?.Invoke(room, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidNameRepairException("При добавлении вида работы произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Информация о поселении
        /// </summary>
        /// <param name="settlement"></param>
        public void AddSettlement(Repair settlement)
        {
            if (settlement.NameStanok.Mark == "" || settlement.NameRepair.Duration == 0)
            {
                throw new InvalidRepairException("Информация о мастерской заполнена некорректно");
            }
            try
            {
                _repairs.Add(settlement);
                //Герерируем событие о том, что информация о поселении добавлена
                RepairAdded?.Invoke(settlement, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidRepairException("В мастерской произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Удалить клиента по идентификатору
        /// </summary>
        /// <param name="clientKey">Идентификатор клиента</param>
        public void RemoveClient(int clientKey)
        {
            _craftbanchs.Remove(clientKey);
            //Генерируем событие о том, что клиент удалён
            CraftbanchRemoved?.Invoke(clientKey, EventArgs.Empty);
            //Получаем список сведений о поселении клиента
            var settlementsForClient = Repairs.Where(s => s.NameStanok.CraftbanchId == clientKey).ToList();
            
            for (int i = 0; i < settlementsForClient.Count; i++)
            {
                //Удаляем сведения о поселении клиента
                RemoveSettlement(settlementsForClient[i]);
            }
        }

        /// <summary>
        /// Удалить номер по идентификатору
        /// </summary>
        /// <param name="roomKey"></param>
        public void RemoveRoom(int roomKey)
        {
            _nameRepairs.Remove(roomKey);
            //Генерируем событие о том, что номер удалён
            NameRepairRemoved?.Invoke(roomKey, EventArgs.Empty);
            //Получаем список сведений о поселении в номер
            var settlementsForRoom = Repairs.Where(s => s.NameRepair.NameRepairId == roomKey).ToList();
            for (int i = 0; i < settlementsForRoom.Count; i++)
            {
                //Удаляем сведения о поселении в номер
                RemoveSettlement(settlementsForRoom[i]);
            }
        }
        /// <summary>
        /// Удалить информацию о поселении
        /// </summary>
        /// <param name="settlement">Информация о поселении</param>
        public void RemoveSettlement(Repair settlement)
        {
            _repairs.Remove(settlement);
            //Генерируем событие о том, что информация о поселении удалена
            RepairRemoved?.Invoke(settlement, EventArgs.Empty);
        }

    }
}
