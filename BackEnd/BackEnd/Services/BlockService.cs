using BackEnd.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
namespace BackEnd.Services
{
    public class BlockService
    {
        private IMongoCollection<Block> _blocks;
        private IMongoCollection<MemPool> _memPoll;

        public BlockService(IBlockSettings settings)
        {
            var client = new MongoClient(settings.Server);

            var database = client.GetDatabase(settings.Database);


            IMongoCollection<Block> mongoCollection = database.GetCollection<Block>(settings.Collection);

            _blocks = mongoCollection;
        }

        public IMongoCollection<MemPool> Mempoll(IMemPoolSettings settings)
        {
            var client = new MongoClient(settings.Server);

            var database = client.GetDatabase(settings.Database);


            IMongoCollection<MemPool> mongoCollection = database.GetCollection<MemPool>(settings.Collection);

            _memPoll = mongoCollection;
            return _memPoll;

        }

        public List<Block> getAllBlock()
        {
            //int result = (from d in _blocks.AsQueryable<Block>()
            //            select d).ToList().Count;

            return _blocks.Find(d => true).ToList();
          //  return result;
        }

        public Block CreateBlock(Block block)
        {

            _blocks.InsertOne(block);
            return block;
        }
        public int getSizeBlocks() {
            return _blocks.Find(d => true).ToList().Count;
        }

        public List<Block> getLastBlock()
        {

            var result = (from _blocks in _blocks.AsQueryable<Block>()
                          orderby _blocks.IdBlock descending
                          select _blocks).Take(1).ToList();
            return result;
        }
    }
}

