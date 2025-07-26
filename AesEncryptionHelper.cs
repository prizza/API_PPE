using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace API_PPE
{

    public class AesEncryptionHelper
    {
        private readonly string _key;
        private readonly string _iv;

        public AesEncryptionHelper(IOptions<EncryptionSettings> options)
        {
            _key = options.Value.Key;
            _iv = options.Value.IV;
        }

        public string Encrypt(string plainText)
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes(_key);
                byte[] iv = Encoding.UTF8.GetBytes(_iv);

                using Aes aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;

                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter writer = new(cs))
                {
                    writer.Write(plainText);
                } // pastikan semua stream ditutup & flushed di sini

                string result = Convert.ToBase64String(ms.ToArray());
                System.Diagnostics.Debug.WriteLine("Encryption result: " + result);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Encryption error: " + ex.Message);
                return null;
            }
        }

        public string Decrypt(string cipherText)
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes(_key);
                byte[] iv = Encoding.UTF8.GetBytes(_iv);
                byte[] buffer = Convert.FromBase64String(cipherText);

                using Aes aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;

                using MemoryStream ms = new(buffer);
                using (CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader reader = new(cs))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Decryption error: " + ex.Message);
                return null;
            }
        }
    }
}
