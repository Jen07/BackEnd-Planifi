using BackEnd.Models;
using MongoDB.Driver;
using System.Collections.Generic;


namespace BackEnd.Services
{
    public class MemPoolService
    {
        private IMongoCollection<MemPool> _memPoll;

        public MemPoolService(IMemPoolSettings settings)
        {
            var client = new MongoClient(settings.Server);

            var database = client.GetDatabase(settings.Database);


            IMongoCollection<MemPool> mongoCollection = database.GetCollection<MemPool>(settings.Collection);

            _memPoll = mongoCollection;
        }

        public List<MemPool> AllConfiguration()
        {
            return _memPoll.Find(d => true).ToList();
        }

        public MemPool Create(MemPool memPool)
        {
            _memPoll.InsertOne(memPool);
            return memPool;
        }

        public void Delete(string id)
        {
            _memPoll.DeleteOne(d => d.Id == id);
        }

      

    }
}
