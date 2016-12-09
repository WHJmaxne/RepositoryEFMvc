using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Common
{
    public static class StringExtension
    {
        #region 1.0 计算字符串的MD5值
        /// <summary>
        /// 计算字符串的MD5值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btyValue, btyHash;
            btyValue = Encoding.UTF8.GetBytes(str);
            btyHash = md5.ComputeHash(btyValue);
            md5.Clear();
            string sTemp = string.Empty;
            for (int i = 0; i < btyHash.Length; i++)
            {
                sTemp += btyHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
        #endregion

        #region 2.0 判断两个字符串是否相等，忽略大小写
        /// <summary>
        /// 判断两个字符串是否相等，忽略大小写
        /// </summary>
        /// <param name="strOri">本字符串</param>
        /// <param name="newStr">要比较的字符串</param>
        /// <returns></returns>
        public static bool IsSameStr(this string strOri, string newStr)
        {
            return strOri.Equals(newStr, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion

        #region 3.0 判断字符串是否为空
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        #endregion
    }
}
