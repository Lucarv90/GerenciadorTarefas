using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Projeto.Util
{
    public class Criptografia
    {
        public string ToEncrypt(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = md5.ComputeHash(senhaBytes);

            string result = string.Empty;
            foreach (byte b in hash)
            {
                result += b.ToString("x");
            }
            return result;
        }
    }
}
