using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Hash
{
    public static class HashHelper
    {
        public static byte[] HashExistPassword(string password)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(password);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(data);
            return result;
        }

        public static byte[] HashInputPassword(string password)
        {
            var sha2 = SHA256.Create();
            var hbyte = sha2.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] data = new UTF8Encoding().GetBytes(BitConverter.ToString(hbyte).Replace("-", "").ToLower());
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(data);
            return result;
        }

        public static string ByteArrayToHexString(byte[] byteArray)
        {
            StringBuilder hexString = new StringBuilder(byteArray.Length * 2);


            foreach (byte b in byteArray)
            {
                hexString.AppendFormat("{0:x2}", b);
            }
            return hexString.ToString();
        }

        public static string HashInputPasswordToString(string password)
        {
            byte[] hashedBytes = HashInputPassword(password);
            return ByteArrayToHexString(hashedBytes);
        }

        public static string HashExistPasswordToString(string password)
        {
            byte[] hashedBytes = HashExistPassword(password);
            return ByteArrayToHexString(hashedBytes);
        }
    }
}
