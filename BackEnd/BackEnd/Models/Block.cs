using System;
using System.Collections.Generic;
using BackEnd.Logic;
using System.Linq;
using System.Diagnostics;
using System.Timers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.Models
{
    public class Block
    {
        public const string UNO = "1,0000000";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("date")]
        public string TimesStamp { 
            get; set; }

        [BsonElement("test")]
        public int Test { get; set; }

        [BsonElement("milliSeconds")]
        public long MilliSeconds { get; set; }

        [BsonElement("documents")]
        public Transaction[] Documents { get; set; }

        [BsonElement("previousHash")]
        public string PreviousHash { get; set; }

        [BsonElement("Hash")]
        public string Hash { get; set; }

        [BsonElement("idBlock")]
        public int IdBlock { get; set; }

        Stopwatch sw;

        private static Timer tm;
        public string getDate() {

            DateTime date = DateTime.Now;

            return date.ToString("yyyy-MM-dd HH:MM:ss");

        }

        public Block(int index, List<Transaction> transacciones, string previousHash)
        {
            IdBlock = index;
            Documents = transacciones != null ? transacciones.ToArray() : new Transaction[0];
            TimesStamp = getDate();
            PreviousHash = previousHash;
            sw = new Stopwatch();
        }
        
        private bool HashIsValid(string text, int difficulty)//Dificulti, es el numero de ceros por el que debe empezar el hash
        {
            string hash = HashHelper.CalculateHash(text);
            string zeros = string.Empty.PadLeft(difficulty, '0');
            return hash.StartsWith(zeros);

        }

        private static long TimeStapSeconds(DateTime datime) =>
            (long)datime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

        public string  ListConcat(){
            string result = string.Empty;
            System.Text.StringBuilder sbf = new System.Text.StringBuilder();


            for (int i = 0; i< Documents.Length; i++) {

                sbf.AppendJoin('@',HashHelper.CalculateHash(Documents[i].Base64));
            }

            return sbf.ToString();

         }
        public string MineBlock(int dificulty,Block newBlock)
        {

            // string initialText = string.Format("{0}{1}{2}", Id, TimesStamp, Documents.Select(va => va.Hash).Aggregate((i, j) => i + j));
            // Console.WriteLine(ListConcat().Length);

            string sha = ListConcat();
            string initialText = string.Format("{0}{1}{2}{3}", IdBlock, TimesStamp, sha, PreviousHash);
            Test = 0;
          
            string text = string.Format("{0}{1}", initialText, Test);
           long timestamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();

          long sec =  TimeStapSeconds(DateTime.Now) + 1;

            long miliSeconds = 0;
          
            while (!HashIsValid(text, dificulty))
            {
               // Console.WriteLine(TimeStapSeconds(DateTime.Now));

                if (sec == TimeStapSeconds(DateTime.Now)) {
                   
                    //Console.WriteLine("Segundo "+ sec + " TimeStapSeconds "+ TimeStapSeconds(DateTime.Now));
                    Test = 0;
                  
                  //  Console.WriteLine("Test "+Test);
                    sec = TimeStapSeconds(DateTime.Now) + 1;
                    
                }
                Test++;
                text = string.Format("{0}{1}", initialText, Test);
              //Console.WriteLine("Test "+ Test+ " Testo: "+ text);
            }
           // Console.WriteLine("Holaaaaa");
           
            long di = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            miliSeconds = di - timestamp;
            Hash = HashHelper.CalculateHash(text);
            newBlock.Hash = Hash;
            newBlock.Test = Test;
            newBlock.getDate();
            newBlock.MilliSeconds = miliSeconds;
            System.Diagnostics.Debug.WriteLine("Despues de Minado  "+newBlock.IdBlock);
          //  return null;
            //fecha
            //milisegundos


            //  Console.WriteLine("hASHHHHHHHHHHH "+newBlock.Hash);
            //  Console.WriteLine("hASHHHHHHHHHHH " + newBlock.MilliSeconds);
            //   Console.WriteLine("hASHHHHHHHHHHH " + newBlock.TimesStamp);

            return "hola";
        }
     

    }
}
