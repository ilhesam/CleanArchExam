using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationCore.Security
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Encrypt using MD5
        /// </summary>
        /// <param name="password">Password to Encrypt</param>
        /// <returns>Encrypted Password</returns>
        public static string EncodePasswordMd5(this string password)   
        {
            // Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password);
            var encodedBytes = md5.ComputeHash(originalBytes);

            // Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }
    }
}
