using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WPP.Helpers
{
    public class WPPHelper
    {
        public static string MD5Encryptor(string text)
        {
            MD5 encryptor = new MD5CryptoServiceProvider();
            StringBuilder strBuilder = new StringBuilder();

            encryptor.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = encryptor.Hash;

            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }


    }
}