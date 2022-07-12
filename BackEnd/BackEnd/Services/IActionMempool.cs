using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Services
{
    public interface IActionMempool
    {
        public MemPool Create(MemPool memPool);

        public List<MemPool> mineList(int cantidad);

        public List<MemPool> AllConfiguration();

    }
}
