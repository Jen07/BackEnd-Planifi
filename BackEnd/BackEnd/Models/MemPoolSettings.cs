namespace BackEnd.Models
{
    public class MemPoolSettings : IMemPoolSettings
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }

    }

    public interface IMemPoolSettings
    {
        string Server { get; set; }

        string Database { get; set; }

        string Collection { get; set; }
    }
}
