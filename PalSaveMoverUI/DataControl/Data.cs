using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SaveGameMover.DataControl
{
	public class SaveDataManager
	{
		public readonly List<SaveData> SaveData;

		public SaveDataManager()
		{
			SaveData = [];
		}

		public void AddSaveData(string sourcePath, string destinationPath, string name)
		{
			SaveData saveData = new(sourcePath, destinationPath, name);
			SaveData.Add(saveData);
		}

		public void SaveAllToFile(string password)
		{
			using StreamWriter writer = new("data.dat");
			foreach (SaveData saveData in SaveData)
			{
				string encryptedData = saveData.EncryptData(password);
				writer.WriteLine(encryptedData);
			}
		}

		public void ReadAllFromFile(string password)
		{
			SaveData.Clear();

			using StreamReader reader = new("data.dat");
			string encryptedData;
			while ((encryptedData = reader.ReadLine()) != null)
			{
				string decryptedData = DataControl.SaveData.DecryptData(encryptedData, password);
				string[] dataParts = decryptedData.Split('|');

				if (dataParts.Length == 4)
				{
					string sourcePath = dataParts[0];
					string destinationPath = dataParts[1];
					string name = dataParts[2];
					string guid = dataParts[3];

					SaveData saveData = new(sourcePath, destinationPath, name)
					{
						GUID = guid
					};

					SaveData.Add(saveData);
				}
			}
		}
		public bool IsFirstRun()
		{
			return !File.Exists("data.dat");
		}
	}

	public class SaveData
	{
		public string SourcePath { get; set; }
		public string DestinationPath { get; set; }
		public string Name { get; set; }
		public string GUID { get; set; } = "-1";

		public SaveData(string sourcePath, string destinationPath, string name)
		{
			SourcePath = sourcePath;
			DestinationPath = destinationPath;
			Name = name;
			GUID = GenerateGUID();
		}

		public override string ToString()
		{
			return Name;
		}

		private string GenerateGUID()
		{
			return Guid.NewGuid().ToString();
		}

		public string EncryptData(string password)
		{
			string plainText = SourcePath + "|" + DestinationPath + "|" + Name + "|" + GUID;
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
			byte[] salt = new byte[16];

			using Rfc2898DeriveBytes derivedBytes = new(passwordBytes, salt, 10000);
			byte[] key = derivedBytes.GetBytes(32);
			byte[] iv = derivedBytes.GetBytes(16);

			using Aes aes = Aes.Create();
			aes.Key = key;
			aes.IV = iv;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;

			// Create an encryptor to perform the stream transform
			ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

			// Create the streams used for encryption
			using MemoryStream msEncrypt = new();
			using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
			{
				using StreamWriter swEncrypt = new(csEncrypt);
				// Write all data to the stream
				swEncrypt.Write(plainText);
			}
			return Convert.ToBase64String(msEncrypt.ToArray());
		}

		public static string DecryptData(string encryptedData, string password)
		{
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
			byte[] salt = new byte[16]; // Generate a random salt

			using Rfc2898DeriveBytes derivedBytes = new(passwordBytes, salt, 10000);
			byte[] key = derivedBytes.GetBytes(32); // AES 256-bit key
			byte[] iv = derivedBytes.GetBytes(16); // 128-bit IV

			using Aes aes = Aes.Create();
			aes.Key = key;
			aes.IV = iv;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;

			// Create a decryptor to perform the stream transform
			ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

			// Create the streams used for decryption
			using MemoryStream msDecrypt = new(Convert.FromBase64String(encryptedData));
			using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
			using StreamReader srDecrypt = new(csDecrypt);
			// Read the decrypted bytes from the decrypting stream
			// and place them in a string
			return srDecrypt.ReadToEnd();
		}
	}

}

