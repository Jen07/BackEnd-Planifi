namespace BackEnd.Models
{
    public class BlockSettings : IBlockSettings
    {
            public string Server { get; set; }

            public string Database { get; set; }

            public string Collection { get; set; }
        }
        public interface IBlockSettings
        {
            string Server { get; set; }

            string Database { get; set; }

            string Collection { get; set; }
        }
}
