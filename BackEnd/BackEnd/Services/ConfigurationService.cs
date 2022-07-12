
using BackEnd.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace BackEnd.Services
{
    public class ConfigurationService:IAction,IActionConfiguration
    {
        private IMongoCollection<Configuration> _configuraciones;
        public ConfigurationService(IConfigurationSetting settings)
        {
            var client = new MongoClient(settings.Server);

            var database = client.GetDatabase(settings.Database);


            IMongoCollection<Configuration> mongoCollection = database.GetCollection<Configuration>(settings.Collection);

            _configuraciones = mongoCollection;
        }
        public void Delete(string id)
        {
            _configuraciones.DeleteOne(d => d.Id == id);
        }
        public int getSizeList()
        {
            return _configuraciones.Find(d => true).ToList().Count;
        }
        public void Update(string id, Configuration config)
        {
            _configuraciones.ReplaceOne(user => user.Id == id, config);
        }
        public Configuration Create(Configuration config)
        {
            _configuraciones.InsertOne(config);
            return config;
        }
        public List<Configuration> AllConfiguration()
        {
            return _configuraciones.Find(d => true).ToList();
        }
        public List<Configuration> numeroBloque(string variableSistema)
        {
            var result = (from d in _configuraciones.AsQueryable<Configuration>()
                         where d.VariableSistema.Equals(variableSistema)
                         select d).ToList();
            return result;
        }
      }
    }

