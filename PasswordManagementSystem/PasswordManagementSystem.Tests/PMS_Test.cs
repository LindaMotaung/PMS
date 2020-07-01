using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace PasswordManagementSystem.Tests
{
    /*Naming convention follows:
      Roy Osherove's naming strategy of unit tests:

      [UnitOfWork_StateUnderTest_ExpectedBehaviour]*/

    [TestClass]
    public class PMS_Test
    {
        private string publicTestKeyPath = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem.Tests\TestKeyValues\Public.cert";
        private string privateTestKeyPath = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem.Tests\TestKeyValues\Private.cert";
        private static byte[] encryptedData = new byte[] { };
        private Repositories.Crypto crytoObj = new Repositories.Crypto();
        private static string plainTextData { get; set; }

        [TestMethod]
        public void Crypto_ByteArray_ReturnsByteArray()
        {
            Encrypt_ByteArray_ReturnsByteArray();
            Dencrypt_ByteArray_ReturnsByteArray();
        }

        public void Encrypt_ByteArray_ReturnsByteArray()
        {
            //Arrange
            string plainText = "The boy kicked the ball";
            plainTextData = plainText;

            //Act        
            CreateKeysTestFunc();
            byte[] actual = crytoObj.encrypt(Encoding.UTF8.GetBytes(plainText), publicTestKeyPath);
            encryptedData = actual;

            //Assert
            Assert.IsNotNull(actual, "An error was encountered while performing encryption");
        }

        public void Dencrypt_ByteArray_ReturnsByteArray()
        {
            //Arrange
            byte[] encryptedDataVariable = encryptedData;

            //Act
            byte[] actual = crytoObj.decrypt(encryptedDataVariable, privateTestKeyPath);
            string decryptedString = Encoding.UTF8.GetString(actual);

            //Assert
            Assert.AreEqual(decryptedString, plainTextData);

        }

        private void CreateKeysTestFunc()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateTestKeyPath))
                    File.Delete(privateTestKeyPath);

                if (File.Exists(publicTestKeyPath))
                    File.Delete(publicTestKeyPath);

                string publicKey = rsa.ToXmlString(false);
                File.WriteAllText(publicTestKeyPath, publicKey);
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(privateTestKeyPath, privateKey);
            }
        }
    }
}
