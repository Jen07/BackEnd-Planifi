using System;
using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Logic
{
    public class HashHelper
    {
        public static string CalculateHash(string text)
        {
            string myHashCalculated = string.Empty;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] encodedText = new UTF8Encoding().GetBytes(text);
                byte[] myHashArray = mySHA256.ComputeHash(encodedText);
                myHashCalculated = BitConverter.ToString(myHashArray).Replace("-", string.Empty);
            }
            return myHashCalculated;
        }
       
    }
}
