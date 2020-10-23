using System;
using System.IO;
using System.Security.Cryptography;

namespace Argos.Authentication
{
    public static class CryptoPassword
    {

        #region atributos

        private static byte[] _Texto_Cripto;
        private static string _Texto_Decripto;
        private static string _Texto_Cripto_Str;

        #endregion

        #region Propriedades


        private static byte[] Chave
        {
            get { return System.Text.ASCIIEncoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("PASSWORD_KEY")); }
        }


        private static byte[] VI
        {
            get { return System.Text.ASCIIEncoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("IV_KEY")); }
        }


        public static byte[] Texto_Cripto
        {
            get { return _Texto_Cripto; }
            set { _Texto_Cripto = value; }
        }

        public static string texto_Decripto
        {
            get { return _Texto_Decripto; }
            set { _Texto_Decripto = value; }
        }

        private static string Texto_Cripto_Str
        {
            get { return _Texto_Cripto_Str; }
            set { _Texto_Cripto_Str = value; }
        }

        #endregion

        #region Encriptar

        public static string Encriptar(string Texto_Origem)
        {

            try
            {
                Texto_Cripto = encryptStringToBytes_AES(Texto_Origem, Chave, VI);
                Converter_Byte_String();

                return Texto_Cripto_Str;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void Converter_Byte_String()
        {
            try
            {
                Texto_Cripto_Str = Convert.ToBase64String(Texto_Cripto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static byte[] encryptStringToBytes_AES(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            // Declare the streams used
            // to encrypt to an in memory
            // array of bytes.
            MemoryStream msEncrypt = null;
            CryptoStream csEncrypt = null;
            StreamWriter swEncrypt = null;

            // Declare the RijndaelManaged object
            // used to encrypt the data.
            RijndaelManaged aesAlg = null;


            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                msEncrypt = new MemoryStream();
                csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                swEncrypt = new StreamWriter(csEncrypt);

                //Write all data to the stream.
                swEncrypt.Write(plainText);

            }
            finally
            {
                // Clean things up.
                // Close the streams.
                if ((swEncrypt != null))
                {
                    swEncrypt.Close();
                }
                if ((csEncrypt != null))
                {
                    csEncrypt.Close();
                }
                if ((msEncrypt != null))
                {
                    msEncrypt.Close();
                }
                // Clear the RijndaelManaged object.
                if ((aesAlg != null))
                {
                    aesAlg.Clear();
                }
            }
            // Return the encrypted bytes from the memory stream.
            return msEncrypt.ToArray();

        }


        #endregion

        #region Decriptografar

        public static string Decriptar(string texto_criptografado)
        {

            try
            {
                if (texto_criptografado == string.Empty)
                    return string.Empty;

                // Descriptografa a string (pode ser o array de bytes, 
                // como no exemplo original"
                texto_Decripto = decryptStringFromBytes_AES(Convert.FromBase64String(texto_criptografado), Chave, VI);
                // Exibe string descriptografada.
                return texto_Decripto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string decryptStringFromBytes_AES(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            
            MemoryStream msDecrypt = null;
            CryptoStream csDecrypt = null;
            StreamReader srDecrypt = null;

            RijndaelManaged aesAlg = null;

            string plaintext = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                msDecrypt = new MemoryStream(cipherText);
                csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                srDecrypt = new StreamReader(csDecrypt);

                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEnd();
            }
            finally
            {
                // Clean things up.
                // Close the streams.
                if ((srDecrypt != null))
                {
                    srDecrypt.Close();
                }
                if ((csDecrypt != null))
                {
                    csDecrypt.Close();
                }
                if ((msDecrypt != null))
                {
                    msDecrypt.Close();
                }
                // Clear the RijndaelManaged object.
                if ((aesAlg != null))
                {
                    aesAlg.Clear();
                }
            }
            return plaintext;

        }

        public static bool VerifyPassword(string PasswordSalva, string PasswordDigitada)
        {
            return CryptoPassword.Decriptar(PasswordSalva).Equals(PasswordDigitada);
        }

        #endregion        
    }
}