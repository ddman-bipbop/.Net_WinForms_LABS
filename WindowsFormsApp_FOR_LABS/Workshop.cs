using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp_FOR_LABS;

namespace lab5
{
    public class Workshop
    {
        public event EventHandler ClientAdded;
        public event EventHandler RoomAdded;
        public event EventHandler SettlementAdded;
        public event EventHandler ClientRemoved;
        public event EventHandler RoomRemoved;
        public event EventHandler SettlementRemoved;


        /// <summary>
        /// Словарь станков
        /// </summary>
        private Dictionary<int, Craftbanch> _clients = new Dictionary<int, Craftbanch>();

        /// <summary>
        /// Словарь видов ремонта
        /// </summary>
        private Dictionary<int, NameRepair> _rooms = new Dictionary<int, NameRepair>();

        /// <summary>
        /// Список ремонтов
        /// </summary>
        private List<Repair> _settlements = new List<Repair> ();

        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        public IEnumerable<Craftbanch> Clients
        {
            get { return _clients.Values.AsEnumerable(); }
        }
        /// <summary>
        /// Коллекция номеров
        /// </summary>
        public IEnumerable<NameRepair> Rooms
        {
            get
            {
                return _rooms.Values.AsEnumerable();
            }
        }
        /// <summary>
        /// Коллекция поселений
        /// </summary>
        public IEnumerable<Repair> Settlements
        {
            get
            {
                return _settlements;
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
                throw new InvalidCraftbanchException("Информация о клиент заполнена некорректно");
            }
            try
            {
                _clients.Add(client.CraftbanchId, client);
                //Герерируем событие о том, что клиент добавлен
                ClientAdded?.Invoke(client, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidCraftbanchException("При добавлении клиента произошла ошибка", exception);
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
                throw new InvalidNameRepairException("Информация о номере заполнена некорректно");
            }
            try
            {
                _rooms.Add(room.NameRepairId, room);
                //Герерируем событие о том, что номер добавлен
                RoomAdded?.Invoke(room, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidNameRepairException("При добавлении номера произошла ошибка", exception);
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
                throw new InvalidRepairException("Информация о заселении заполнена некорректно");
            }
            try
            {
                _settlements.Add(settlement);
                //Герерируем событие о том, что информация о поселении добавлена
                SettlementAdded?.Invoke(settlement, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidRepairException("При поселении произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Удалить клиента по идентификатору
        /// </summary>
        /// <param name="clientKey">Идентификатор клиента</param>
        public void RemoveClient(int clientKey)
        {
            _clients.Remove(clientKey);
            //Генерируем событие о том, что клиент удалён
            ClientRemoved?.Invoke(clientKey, EventArgs.Empty);
            //Получаем список сведений о поселении клиента
            var settlementsForClient = Settlements.Where(s => s.NameStanok.CraftbanchId == clientKey).ToList();
            
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
            _rooms.Remove(roomKey);
            //Генерируем событие о том, что номер удалён
            RoomRemoved?.Invoke(roomKey, EventArgs.Empty);
            //Получаем список сведений о поселении в номер
            var settlementsForRoom = Settlements.Where(s => s.NameRepair.NameRepairId == roomKey).ToList();
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
            _settlements.Remove(settlement);
            //Генерируем событие о том, что информация о поселении удалена
            SettlementRemoved?.Invoke(settlement, EventArgs.Empty);
        }

    }
}
