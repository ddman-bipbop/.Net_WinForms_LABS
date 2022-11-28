using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEmployees.Exception;

namespace ClassLibraryEmployees
{
    /// <summary>
    /// Компания
    /// </summary>
    public class Company 
    {
        private static Company _instance;
        /// <summary>
        /// Единственный экземпляр класса Отель
        /// </summary>
        public static Company Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Company();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private Company()
        {}


        /// <summary>
        /// Словарь сотрудников
        /// </summary>
        private Dictionary<int, Employees> _employeess { get; } = new Dictionary<int, Employees>();
        /// <summary>
        /// Словарь видов работ
        /// </summary>
        private Dictionary<string, TypeWork> _typeWorks { get; } = new Dictionary<string, TypeWork>();

        /// <summary>
        /// Спосок работ
        /// </summary>
        private List<Work> _works { get; } = new List<Work>();



        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public IEnumerable<Employees> Employeess
        {
            get { return _employeess.Values.AsEnumerable(); }
        }
        /// <summary>
        /// Коллекция видов работ
        /// </summary>
        public IEnumerable<TypeWork> TypeWorks
        {
            get
            {
                return _typeWorks.Values.AsEnumerable();
            }
        }
        /// <summary>
        /// Коллекция работ
        /// </summary>
        public IEnumerable<Work> Works
        {
            get
            {
                return _works;
            }
        }


        public event EventHandler EmployeesAdded;
        public event EventHandler TypeWorkAdded;
        public event EventHandler WorkAdded;
        public event EventHandler EmployeesRemoved;
        public event EventHandler TypeWorkRemoved;
        public event EventHandler WorkRemoved;

        //Для изменения коллекций реализуем специальные методы 

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employees">Информация о сотруднике</param>
        public void AddEmpl(Employees empl)
        {
            if (!empl.IsValid)
            {
                throw new InvalidEmployeesException("Информация о сотруднике заполнена некорректно");
            }
            try
            {
                _employeess.Add(empl.EmployeesId, empl);
                //Герерируем событие о том, что сотрудник добавлен
                EmployeesAdded?.Invoke(empl, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidEmployeesException("При добавлении сотрудника произошла ошибка", exception);
            }
        }


        /// <summary>
        /// Добавление вида работы
        /// </summary>
        /// <param name="typeWork">Информация о виде работы</param>
        public void AddTypeWork(TypeWork typeWork)
        {
            if (!typeWork.IsValid)
            {
                throw new InvalidTypeWorkException("Информация о типе работы некорректно");
            }
            try
            {
                _typeWorks.Add(typeWork.WorkInfo.NameWork, typeWork);
                //Герерируем событие о том, что вид работы добавлен
                TypeWorkAdded?.Invoke(typeWork, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidTypeWorkException("При добавлении вида работы произошла ошибка", exception);
            }
        }


        /// <summary>
        /// Информация о работе
        /// </summary>
        /// <param name="work"></param>
        public void AddWork(Work work)
        {
            if (!work.IsValid)
            {
                throw new InvalidWorkException("Информация о работе заполнена некорректно");
            }
            try
            {
                _works.Add(work);
                //Герерируем событие о том, что информация о работе добавлена
                WorkAdded?.Invoke(work, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidWorkException("При добавлении работы произошла ошибка", exception);
            }
        }


        /// <summary>
        /// Удалить сотрудника по идентификатору
        /// </summary>
        /// <param name="employeesKey">Идентификатор сотрудника</param>
        public void RemoveEmpl(int emplKey)
        {
            _employeess.Remove(emplKey);
            //Генерируем событие о том, что сотрудник удалён
            EmployeesRemoved?.Invoke(emplKey, EventArgs.Empty);
            //Получаем список сведений о работе сотрудника
            var WorksForEmpl = Works.Where(s => s.Employees.EmployeesId == emplKey).ToList();
            for (int i = 0; i < WorksForEmpl.Count; i++)
            {
                //Удаляем сведения о работе сотрудника
                RemoveWork(WorksForEmpl[i]);
            }
        }

        /// <summary>
        /// Удалить вид работы по идентификатору
        /// </summary>
        /// <param name="TypeWorkKey"></param>
        public void RemoveTypeWork(string typeWorkKey)
        {
            _typeWorks.Remove(typeWorkKey);
            //Генерируем событие о том, что вид работы удалён
            TypeWorkRemoved?.Invoke(typeWorkKey, EventArgs.Empty);
            //Получаем список сведений о видах работ в работах
            var worksForTypeWork = Works.Where(s => s.TypeWork.WorkInfo.NameWork == typeWorkKey).ToList();
            for (int i = 0; i < worksForTypeWork.Count; i++)
            {
                //Удаляем сведения о работе по виду работы
                RemoveWork(worksForTypeWork[i]);
            }
        }


        /// <summary>
        /// Удалить информацию о работе
        /// </summary>
        /// <param name="work">Информация о работе</param>
        public void RemoveWork(Work work)
        {
            _works.Remove(work);
            //Генерируем событие о том, что информация о работе удалена
            WorkRemoved?.Invoke(work, EventArgs.Empty);
        }
    }
}
