namespace ClassLibraryAuto
{
    [Serializable]
    public class Auto
    {
     
        /// <summary>
        /// Марка машины
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Цвет машины
        /// </summary>
        public string Color {get; set; }
        /// <summary>
        /// Дата создания машины
        /// </summary>
        public DateTime DateCreate { get; set; }

    }
    public enum AutoRequestType
    {
        Add,
        Get,
        Update,
        Remove
    }
    public class AutoRequest
    {
        public Auto Auto { get; set; }

        public int Key { get; set; }

        public AutoRequestType Type { get; set; }

    }

    public class AutoResponse
    {
        public Auto Auto { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public int Key { get; set; }
    }
}