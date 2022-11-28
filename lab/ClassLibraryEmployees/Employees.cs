namespace ClassLibraryEmployees
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    [Serializable]
    public class Employees : IValidatable
    {
        /// <summary>
        /// Уникальный идентификатор нового сотрудника (аналог автоинкремента)
        /// </summary>
        private static int _newEmployeesId;
        public static int NewEmployeesId
        {
            get
            {
                _newEmployeesId++;
                return _newEmployeesId;
            }
            set
            {
                _newEmployeesId = value;
            }
        }
        /// <summary>                                   
        /// Уникальный идентификатор сотрудника
        /// </summary>
        public int EmployeesId { get; }


        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = "";

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; } = "";

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = "";

        /// <summary>
        /// Оклад
        /// </summary>
        public int Salary { get; set; } = 0;

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FirstName)) return false;
                if (string.IsNullOrWhiteSpace(MiddleName)) return false;
                if (string.IsNullOrWhiteSpace(LastName)) return false;
                return true;
            }
        }


        public Employees()
        {
            EmployeesId = NewEmployeesId;
        }

        public Employees(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            EmployeesId = NewEmployeesId;
        }

        public override string ToString()
        {
            return $"Фамилия: {LastName}\r\n Имя: {FirstName}\r\n Отчество: {MiddleName}\r\n Оклад: {Salary}\r\n";
        }
    }
}
