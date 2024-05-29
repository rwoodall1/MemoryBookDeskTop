using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Http.Headers;
using BindingModels;

namespace Mbc5.Classes
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return new UTF8Encoding(false); }
        }
    }
    public static class Serialize
    {

        public static string ToXml(object data)
        {

            using (var stringwriter = new Utf8StringWriter())
            {
                try
                {
                    var serializer = new XmlSerializer(data.GetType());
                    serializer.Serialize(stringwriter, data);
                    return stringwriter.ToString();
                }
                catch (Exception ex)
                {
                    return "";
                }
            }

        }
    }
    public static class Encryptor
    {
        public static string Encrypt(string Message, string Passphrase, bool Base64Encode = true)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            var returnVar = Results.ToString();
            if (Base64Encode)
            {
                returnVar = Convert.ToBase64String(Results);
            }
            // Step 6. Return the encrypted string as a base64 encoded string
            return returnVar;
        }

        public static string Decrypt(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt;
            try
            {
                DataToDecrypt = Convert.FromBase64String(Message);
            }
            catch
            {
                return "ERROR";
            }

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }


    }
    //public class ApplicationConfig
    //{
    //    private static readonly object LockObject = new object();

    //    private static volatile string _SQLPassphrase;
    //    private static volatile string _mbcConnectionString;






    //}
  
}


