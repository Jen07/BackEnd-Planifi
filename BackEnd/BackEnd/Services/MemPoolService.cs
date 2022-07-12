using BackEnd.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;


namespace BackEnd.Services
{
    public class MemPoolService:IAction, IActionMempool
    {
        private IMongoCollection<MemPool> _memPoll;

        public MemPoolService(IMemPoolSettings settings)
        {
            var client = new MongoClient(settings.Server);

            var database = client.GetDatabase(settings.Database);


            IMongoCollection<MemPool> mongoCollection = database.GetCollection<MemPool>(settings.Collection);

            _memPoll = mongoCollection;
        }
        public int getSizeList()
        {
            return _memPoll.Find(d => true).ToList().Count;
        }
        public void Delete(string id)
        {
            _memPoll.DeleteOne(d => d.Id == id);
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
        public List<MemPool> mineList(int cantidad)
        {
            var result = (from d in _memPoll.AsQueryable<MemPool>() 
                         select d).Take(cantidad).ToList();
            return result as List<MemPool>;
        }

    }
}
