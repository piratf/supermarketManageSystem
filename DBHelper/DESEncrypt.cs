using System;
using System.Security.Cryptography;  
using System.Text;

namespace DataBaseHelper
{
	/// <summary>
	/// DES加密/解密类。
	/// </summary>
	public class DESEncrypt
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="DESEncrypt"/> class.
        /// </summary>
		public DESEncrypt()
		{			
		}

		#region ========加密======== 
 
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string Encrypt(string Text) 
		{
            return Encrypt(Text, "author:panxiongfei");
		}
		/// <summary> 
		/// 加密数据 
		/// </summary> 
		/// <param name="Text"></param> 
		/// <param name="sKey"></param> 
		/// <returns></returns> 
		public static string Encrypt(string Text,string sKey) 
		{ 
			DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
			byte[] inputByteArray; 
			inputByteArray=Encoding.Default.GetBytes(Text); 
			des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			System.IO.MemoryStream ms=new System.IO.MemoryStream(); 
			CryptoStream cs=new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write); 
			cs.Write(inputByteArray,0,inputByteArray.Length); 
			cs.FlushFinalBlock(); 
			StringBuilder ret=new StringBuilder(); 
			foreach( byte b in ms.ToArray()) 
			{ 
				ret.AppendFormat("{0:X2}",b); 
			} 
			return ret.ToString(); 
		} 

		#endregion
		
		#region ========解密======== 
   
 
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string Decrypt(string Text) 
		{
            return Decrypt(Text, "author:panxiongfei");
		}
		/// <summary>
		/// 解密数据
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="sKey"></param>
		/// <returns></returns>
		public static string Decrypt(string Text,string sKey) 
		{ 
			DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
			int len;//数组长度
			len=Text.Length/2;
			byte[] inputByteArray = new byte[len];
            int iterator;//遍历数组
            int integer;//暂存数字内容
			for(iterator = 0;iterator < len; iterator++)
			{
				integer = Convert.ToInt32(Text.Substring(iterator * 2, 2),16); 
				inputByteArray[iterator]=(byte)integer; 
			} 
			des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			System.IO.MemoryStream ms=new System.IO.MemoryStream(); 
			CryptoStream cs=new CryptoStream(ms,des.CreateDecryptor(),CryptoStreamMode.Write); 
			cs.Write(inputByteArray,0,inputByteArray.Length); 
			cs.FlushFinalBlock(); 
			return Encoding.Default.GetString(ms.ToArray()); 
		} 
 
		#endregion 


	}
}
