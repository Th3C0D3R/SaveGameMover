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
            SaveData = new List<SaveData>();
        }

        public void AddSaveData(string sourcePath, string destinationPath, string name)
        {
            SaveData saveData = new SaveData(sourcePath, destinationPath, name);
            SaveData.Add(saveData);
        }

        public void SaveAllToFile(string password)
        {
            using (StreamWriter writer = new StreamWriter("data.dat"))
            {
                foreach (SaveData saveData in SaveData)
                {
                    string encryptedData = saveData.EncryptData(password);
                    writer.WriteLine(encryptedData);
                }
            }
        }

        public void ReadAllFromFile(string password)
        {
            SaveData.Clear();

            using (StreamReader reader = new StreamReader("data.dat"))
            {
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

                        SaveData saveData = new SaveData(sourcePath, destinationPath, name)
                        {
                            GUID = guid
                        };

                        SaveData.Add(saveData);
                    }
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
        public string GUID { get; set; }

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
            byte[] dataBytes = Encoding.UTF8.GetBytes(SourcePath + "|" + DestinationPath + "|" + Name + "|" + GUID);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (Aes aes = Aes.Create())
            {
                aes.Key = passwordBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] encryptedBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public static string DecryptData(string encryptedData, string password)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (Aes aes = Aes.Create())
            {
                byte[] iv = new byte[aes.BlockSize / 8];
                Array.Copy(encryptedBytes, 0, iv, 0, iv.Length);

                aes.Key = passwordBytes;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedBytes, iv.Length, encryptedBytes.Length - iv.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] decryptedBytes = memoryStream.ToArray();
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}
