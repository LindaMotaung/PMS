using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagementSystem.Interfaces;
using PasswordManagementSystem.Utilities;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using PasswordManagementSystem.Entities;
using PasswordManagementSystem.Entities.DataContext;

namespace PasswordManagementSystem.Repositories
{
    public class ApplicationAccounts : IApplicationAccounts
    {
        private Crypto cryptoObj;
        private string procedureName = string.Empty;

        public ApplicationAccounts()
        {
            cryptoObj = new Crypto();
        }

        public void addAcccount(string[] array)
        {
            using (var db = new PMS_DBEntities())
            {
                byte[] byteArray = Utility.objectToByteArray(array);

                cryptoObj.createKeys(Utility.storedApplicationPrivateKey, Utility.storedApplicationPublicKey);
                byte[] encrytedData = cryptoObj.encrypt(byteArray, Utility.storedApplicationPublicKey);

                insertApplicationAccountIntoDB(encrytedData);
                Utility.decryptedAccountsVaultList = decipheredListOfVaultAccounts(db);
            }
        }

        public void refreshData()
        {
            using (var db = new PMS_DBEntities())
                Utility.decryptedAccountsVaultList = decipheredListOfVaultAccounts(db);
        }

        private void insertApplicationAccountIntoDB(byte[] array)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Utility.connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddApplicationAccount", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = sqlConnection;
                cmd.Connection.Open();

                SqlParameter paraApplication = new SqlParameter();
                paraApplication.ParameterName = "@Application";
                paraApplication.Value = array;
                paraApplication.DbType = DbType.Binary;
                cmd.Parameters.Add(paraApplication);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private void deleteAccountsVaultEntry(int Id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Utility.connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteAccountsVaultEntry", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = sqlConnection;
                cmd.Connection.Open();

                SqlParameter paraID = new SqlParameter();
                paraID.ParameterName = "@Id";
                paraID.Value = Id;
                paraID.DbType = DbType.Int32;
                cmd.Parameters.Add(paraID);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private void truncateAccountsVaultTable()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Utility.connectionString))
            {
                SqlCommand cmd = new SqlCommand("spTruncateAccountVault", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void updateAccount(string[] array)
        {
            byte[] byteArray = Utility.objectToByteArray(array);

            cryptoObj.createKeys(Utility.accountUpdateKeysPrivateKey, Utility.accountUpdateKeysPublicKey);
            byte[] encrytedData = cryptoObj.encrypt(byteArray, Utility.accountUpdateKeysPublicKey);

            if (encrytedData != null && encrytedData.Count() > 0)
            {
                updateAccount(encrytedData, Utility.appVaultID);
                Utility.errorFlag = false;
            }
        }

        public void updateAccount(byte[] array, int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateAppVault", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = sqlConnection;
                cmd.Connection.Open();

                SqlParameter paraApplication = new SqlParameter();
                paraApplication.ParameterName = "@Application";
                paraApplication.Value = array;
                paraApplication.DbType = DbType.Binary;
                cmd.Parameters.Add(paraApplication);

                SqlParameter paraAppID = new SqlParameter();
                paraAppID.ParameterName = "@Id";
                paraAppID.Value = Id;
                paraAppID.DbType = DbType.Int32;
                cmd.Parameters.Add(paraAppID);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void deleteSelectedAccount(int Id)
        {
            deleteAccountsVaultEntry(Id);
        }

        public void deleteAllAccounts()
        {
            truncateAccountsVaultTable();
        }

        public List<AccountVaultEntity> decipheredListOfVaultAccounts(PMS_DBEntities db)
        {
            byte[] decryptedDBData = new byte[] { };
            List<AccountsVault> listOfDBAccountsVault = db.AccountsVaults.ToList();
            List<AccountVaultEntity> decryptedData = new List<AccountVaultEntity>();
            List<int> IDs = new List<int>();

            foreach (AccountsVault index in listOfDBAccountsVault)
            {
                byte[] encryptedDBData = index.Application;
                Utility.encryptedAccountVaultArray = encryptedDBData;
                int recID = index.Id;

                if (listOfDBAccountsVault.Count > 1)
                {
                    Utility.accountVaultID = index.Id;
                    IDs.Add(Utility.accountVaultID);
                }
                else
                    Utility.accountVaultID = index.Id;


                decryptedDBData = cryptoObj.decrypt(encryptedDBData, Utility.storedApplicationPrivateKey);

                string strResult = Utility.stringManipulation(decryptedDBData);
                string[] stringArr = strResult.Split(new string[] { "  " },
                                  StringSplitOptions.None);
                string[] cleanStrArray = stringArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if (cleanStrArray != null && cleanStrArray.Count() > 0)
                {
                    if (Utility.allFieldsEntered == true)
                    {
                        AccountVaultEntity accountVaultObj = new AccountVaultEntity();
                        accountVaultObj.Id = recID;
                        accountVaultObj.applicationName = cleanStrArray[0];
                        accountVaultObj.username = cleanStrArray[1].TrimStart();
                        accountVaultObj.password = cleanStrArray[2].TrimStart();
                        accountVaultObj.applicationUrl = cleanStrArray[3];
                        accountVaultObj.notes = cleanStrArray[4];

                        decryptedData.Add(accountVaultObj);
                    }
                }
                else
                    Utility.getText = "Something went wrong \n with the decryption!";
            }

            Utility.listOfIDs = IDs;

            return decryptedData;
        }
    }
}
