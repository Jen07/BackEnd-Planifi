namespace BackEnd.Models
{
    public class ConfigurationSetting: IConfigurationSetting
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }
    }
    public interface IConfigurationSetting
    {
        string Server { get; set; }

        string Database { get; set; }

        string Collection { get; set; }
    }
}
