namespace BackEnd.Models
{
    public class UserSettings: IUserSettings
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }
    }

    public interface IUserSettings
    {
         string Server { get; set; }

         string Database { get; set; }

         string Collection { get; set; }
    }
}
