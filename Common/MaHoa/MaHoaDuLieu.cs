using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MaHoa
{
    public class MaHoaDuLieu
    {
        //Mã hóa MD5: Áp dụng vào mã hóa MK
        public string CreateMd5(string data)
        {
            using(System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(data);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //Convert the byte array to hexadecimal string prior to.Net 5
                StringBuilder sb = new System.Text.StringBuilder();
                for (int i= 0; i< hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
