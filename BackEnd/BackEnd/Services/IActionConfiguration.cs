using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Services
{
    public interface IActionConfiguration
    {
        public Configuration Create(Configuration config);

        public void Update(string id, Configuration config);

        public List<Configuration> AllConfiguration();

        public List<Configuration> numeroBloque(string variableSistema);
    }     
}
