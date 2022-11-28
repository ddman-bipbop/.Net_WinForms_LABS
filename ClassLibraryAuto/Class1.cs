namespace ClassLibraryAuto
{

    public class Auto 
    {
        public string Name { get; set; } = "Mark 2";
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

        public string? Key { get; set; }

        public AutoRequestType Type { get; set; }

    }

    public class AutoResponse 
    {
        public Auto? Auto { get; set; }

        public bool IsSuccess { get; set; }

        public string? ErrorMessage { get; set; }

        public string? Key { get; set; }
    }
}