// This file contains the class aesEncryptionDecryption, which is responsible for encryption and decryption functionalities.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class aesEncryptionDecryption
{
    private static readonly byte[] Salt = Encoding.ASCII.GetBytes("your_salt_here");

    public static string EncryptCryptoJSSalted(string plainText, string password)
    {
        using (var aes = Aes.Create())
        {
            var key = new Rfc2898DeriveBytes(password, Salt);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.GenerateIV();

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                ms.Write(aes.IV, 0, aes.IV.Length);
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public static string DecryptCryptoJSSalted(string cipherText, string password)
    {
        var fullCipher = Convert.FromBase64String(cipherText);
        using (var aes = Aes.Create())
        {
            var key = new Rfc2898DeriveBytes(password, Salt);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            var iv = new byte[aes.BlockSize / 8];
            Array.Copy(fullCipher, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}