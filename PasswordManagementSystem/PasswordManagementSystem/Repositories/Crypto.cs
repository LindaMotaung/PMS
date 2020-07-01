using PasswordManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using PasswordManagementSystem.ExceptionHandling;
using PasswordManagementSystem.Utilities;
using System.IO;
using System.Diagnostics;
using PasswordManagementSystem.Entities;

namespace PasswordManagementSystem.Repositories
{
    public class Crypto : ICrypto
    {
        private GeneralExceptions generalExceptions = new GeneralExceptions();

        public byte[] decrypt(byte[] encryptedData, string componentCryptoKey)
        {
            byte[] decryptedData = new byte[] { };

            try
            {
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.PersistKeyInCsp = false;
                    string privateKey = File.ReadAllText(componentCryptoKey);
                    rsa.FromXmlString(privateKey);
                    decryptedData = rsa.Decrypt(encryptedData, true);
                }
            }
            catch (CryptographicException ex)
            {
                //Log exception to the db
                generalExceptions.LogExceptions("Decrypt", Convert.ToString(ex.InnerException), ex.Message, DateTime.Now);
            }

            return decryptedData;
        }

        public byte[] encrypt(byte[] plainText, string componentCryptoKey)
        {
            byte[] encryptedData = new byte[] { };

            try
            {
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.PersistKeyInCsp = false;
                    string publicKey = File.ReadAllText(componentCryptoKey);
                    rsa.FromXmlString(publicKey);
                    encryptedData = rsa.Encrypt(plainText, true);
                }

            }
            catch (CryptographicException ex)
            {
                //Log exception to the db
                generalExceptions.LogExceptions("Encrypt", Convert.ToString(ex.InnerException), ex.Message, DateTime.Now);
            }

            return encryptedData;
        }


        public void createKeys(string privateKeyParams, string publicKeyParams)
        {
            string publicKeyValue = string.Empty;
            string privateKeyValue = string.Empty;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                fileManagement(privateKeyParams, publicKeyParams);

                rsa.PersistKeyInCsp = true;

                if (privateKeyParams.Contains("StoredApplicationUpdateKeys") == true ||
                publicKeyParams.Contains("StoredApplicationUpdateKeys") == true)
                {
                    publicKeyValue = rsa.ToXmlString(false);
                    File.AppendAllText(publicKeyParams, publicKeyValue + Environment.NewLine);

                    privateKeyValue = rsa.ToXmlString(true);
                    File.AppendAllText(privateKeyParams, privateKeyValue + Environment.NewLine);
                }
                else
                {
                    publicKeyValue = rsa.ToXmlString(false);
                    File.WriteAllText(publicKeyParams, publicKeyValue);

                    privateKeyValue = rsa.ToXmlString(true);
                    File.WriteAllText(privateKeyParams, privateKeyValue);
                }
            }
        }


        private static void fileManagement(string privateKeyParams, string publicKeyParams)
        {
            if (privateKeyParams.Contains("ConfirmationCodeKeys") == true ||
                                publicKeyParams.Contains("ConfirmationCodeKeys") == true)
            {
                if (File.Exists(Utility.confirmationCodePrivateKey))
                    File.Delete(Utility.confirmationCodePrivateKey);

                if (File.Exists(Utility.confirmationCodePublicKey))
                    File.Delete(Utility.confirmationCodePublicKey);
            }
            else if (privateKeyParams.Contains("MainPMSUpdateKeys") == true ||
                publicKeyParams.Contains("MainPMSUpdateKeys") == true)
            {
                if (File.Exists(Utility.mainPMSUpdatePrivateKey))
                    File.Delete(Utility.mainPMSUpdatePrivateKey);

                if (File.Exists(Utility.mainPMSUpdatePublicKey))
                    File.Delete(Utility.mainPMSUpdatePublicKey);
            }
            else if (privateKeyParams.Contains("AccountUpdateKeys") == true ||
                publicKeyParams.Contains("AccountUpdateKeys") == true)
            {
                if (File.Exists(Utility.accountUpdateKeysPrivateKey))
                    File.Delete(Utility.accountUpdateKeysPrivateKey);

                if (File.Exists(Utility.accountUpdateKeysPublicKey))
                    File.Delete(Utility.accountUpdateKeysPublicKey);
            }
            else
            {
                if (File.Exists(Utility.privateKey))
                    File.Delete(Utility.privateKey);

                if (File.Exists(Utility.publicKey))
                    File.Delete(Utility.publicKey);
            }
        }

        public void storePublicKey(string publicKeyParams)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddKey", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = sqlConnection;
                    cmd.Connection.Open();

                    SqlParameter paraPublicKey = new SqlParameter();
                    paraPublicKey.ParameterName = "@publicKey";
                    paraPublicKey.Value = Utility.strToByteArray(publicKeyParams);
                    paraPublicKey.DbType = DbType.Binary;
                    cmd.Parameters.Add(paraPublicKey);

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex));
            }
        }
    }
}
