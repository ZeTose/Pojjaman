using System;
using System.Security.Cryptography;
using System.IO;

namespace Longkong.Encryption
{
	/// <summary>
	/// Summary description for Encryptor.
	/// </summary>
	public class Encryptor
	{
		private EncryptTransformer transformer;
		private byte[] initVec;
		private byte[] encKey;

		public Encryptor(EncryptionAlgorithm algId)
		{
			transformer = new EncryptTransformer(algId);
		}

		public byte[] Encrypt(byte[] bytesData, byte[] bytesKey)
		{
			//Set up the stream that will hold the encrypted data.
			MemoryStream memStreamEncryptedData = new MemoryStream();

			transformer.IV = initVec;
			ICryptoTransform transform = 
				transformer.GetCryptoServiceProvider(bytesKey);
			CryptoStream encStream = new CryptoStream(memStreamEncryptedData, 
				transform,
				CryptoStreamMode.Write);
			try
			{
				//Encrypt the data, write it to the memory stream.
				encStream.Write(bytesData, 0, bytesData.Length);
			}
			catch(Exception ex)
			{
				throw new Exception("Error while writing encrypted data to the stream: \n" 
							  + ex.Message);
			}
			//Set the IV and key for the client to retrieve
			encKey = transformer.Key;
			initVec = transformer.IV;
			encStream.FlushFinalBlock();
			encStream.Close();

			//Send the data back.
			return memStreamEncryptedData.ToArray();
		}//end Encrypt

		public byte[] IV
		{
			get{return initVec;}
			set{initVec = value;}
		}

		public byte[] Key
		{
			get{return encKey;}
		}

	}
}
