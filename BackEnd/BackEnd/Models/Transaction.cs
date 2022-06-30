using System;
using BackEnd.Logic;
using System.Linq;
namespace BackEnd.Models
{
    public class Transaction
    {

        public string Base64 { get; set; }
        //public string Hash { get { return HashHelper.CalculateHash(string.Format("{0}",Base64)); } }

        public string TypeOfFile { get; set; }

        public string Name { get; set; }

        public Transaction(string base64,string typeOfFile, string name) 
        {
            Base64 = base64;
            TypeOfFile = typeOfFile;
            Name = name;
            //id,fechaMinado, documentos, hashPrevios, 
            //Hash, Test, Milisegundos
        }

    }
}
