using PasswordManagementSystem.Entities;
using PasswordManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManagementSystem.Utilities
{
    public class Utility
    {
        public static string getText { get; set; }
        public static string getUsername { get; set; }
        public static string getPasswordReminder { get; set; }
        public static bool isUserExists { get; set; }
        public static bool isRefresh { get; set; }
        public static bool isNotesFieldEmpty { get; set; } = false;
        public static bool isApplicationUrlFieldEmpty { get; set; } = false;
        public static bool bothFieldsEmpty { get; set; } = false;
        public static bool allFieldsEntered { get; set; } = false;
        public static bool areKeysEqual { get; set; } = true;
        public static bool errorFlag { get; set; } = true;
        public static bool resetPasswordFlag { get; set; } = false;
        public static List<UserAccountEntity> decryptedList { get; set; }
        public static List<AccountVaultEntity> decryptedAccountsVaultList { get; set; }
        public static AccountVaultEntity updateRec { get; set; }

        public static string myCryptoKeyContainer = "PMS_Vault";

        public static int RSAEncryptionProvider = 1;
        public static int userDataID { get; set; }
        public static int appVaultID { get; set; }
        public static int accountVaultID { get; set; }
        public static List<int> listOfIDs { get; set; }

        public static string publicKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\Public.cert";

        public static string privateKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\Private.cert";

        public static string confirmationCodePublicKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\ConfirmationCodeKeys\Public.cert";

        public static string confirmationCodePrivateKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\ConfirmationCodeKeys\Private.cert";

        public static string mainPMSUpdatePrivateKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\MainPMSUpdateKeys\Private.cert";

        public static string mainPMSUpdatePublicKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\MainPMSUpdateKeys\Public.cert";

        public static string storedApplicationPrivateKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\StoredApplicationUpdateKeys\Private.cert";

        public static string storedApplicationPublicKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\StoredApplicationUpdateKeys\Public.cert";

        public static string accountUpdateKeysPublicKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\AccountUpdateKeys\Public.cert";

        public static string accountUpdateKeysPrivateKey = @"C:\PMS\PasswordManagementSystem\PasswordManagementSystem\Keys\AccountUpdateKeys\Private.cert";

        public static string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        public static byte[] encryptedByteArray { get; set; }
        public static byte[] encryptedAccountVaultArray { get; set; }

        public static byte[] objectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static string randomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void showLabel(Label label, string text, Color color)
        {
            label.Visible = true;
            label.ForeColor = color;
            label.Text = text;
        }

        public static byte[] strToByteArray(string strValue)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(strValue);
        }

        public static string stringManipulation(byte[] decryptedDBData)
        {
            string plainText = Encoding.UTF8.GetString(decryptedDBData, 0, decryptedDBData.Length);
            string manipulatedText = Regex.Replace(plainText, @"[^\t\r\n -~]", " ").Trim();
            manipulatedText.Replace("\t", "");
            string strResult = manipulatedText.Trim();
            return strResult;
        }
    }
}
