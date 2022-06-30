using System;
using System.Collections.Generic;
namespace BackEnd.Models
{
    public class BlockChain
    {
        public const int Dificulty = 4;

        public List<Block> Blocks { get; set; }

        public List<Transaction> TempTransaccions { get; set; }

        public BlockChain()
        {
            Blocks = new List<Block>();
            TempTransaccions = new List<Transaction>();
        }

        public void NewTransaccion(string base64,string typeOfFile,string name)
        {

            Transaction NewTransaccion = new Transaction(base64, typeOfFile, name);

            TempTransaccions.Add(NewTransaccion);

        }
        public void NewBlokc(string previousHash, int idBlock)
        {
           // string previoHash = "0000000000000000000000000000000000000000000000000000000000000000";

          //  if (Blocks.Count > 0)
          //  previoHash = Blocks[idBlock].Hash;
            Block newBlock = new Block(idBlock+1, TempTransaccions, previousHash);
          newBlock.MineBlock(Dificulty, newBlock);
            Blocks.Add(newBlock);


            TempTransaccions = new List<Transaction>();
        }
    }
}
