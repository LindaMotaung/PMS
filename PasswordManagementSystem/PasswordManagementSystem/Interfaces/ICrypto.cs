using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Interfaces
{
    public interface ICrypto
    {
        byte[] encrypt(byte[] plainText, string componentCryptoKey);
        byte[] decrypt(byte[] encryptedData, string componentCryptoKey);
        void createKeys(string privateKeyPath, string publicKeyPath);
        void storePublicKey(string publicKeyParams);
    }
}
