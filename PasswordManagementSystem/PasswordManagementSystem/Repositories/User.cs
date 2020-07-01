using PasswordManagementSystem.Entities;
using PasswordManagementSystem.ExceptionHandling;
using PasswordManagementSystem.Interfaces;
using PasswordManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PasswordManagementSystem.Entities.DataContext;

namespace PasswordManagementSystem.Repositories
{
    public class User : IUser
    {
        private GeneralExceptions generalExceptions = new GeneralExceptions();
        private Crypto cryptoObj;

        public User()
        {
            cryptoObj = new Crypto();
        }

        public bool forgotPassword(string usernameParams, string confirmationCode)
        {
            bool returnVal = false;
            using (var db = new PMS_DBEntities())
            {
                List<UserAccountEntity> decryptedData = decipheredListOfDBUsers(db);
                Utility.decryptedList = decryptedData;
                var resultList = Utility.decryptedList;

                //Verify if the user exists in the db
                var foundItem = resultList.Find(x => x.username.Trim() == usernameParams.Trim());
                if (foundItem != null)
                {
                    string getDBSecurityQuestion = string.Empty;

                    foreach (var index in resultList)
                    {
                        getDBSecurityQuestion = index.passwordReminder;
                    }

                    if (Utility.getPasswordReminder == getDBSecurityQuestion)
                    {
                        //Get the confirmation code that was encrypted in the db
                        List<ConfirmationCodesEntity> returnDBConfirmationCode = decipheredListOfConfirmationCodes(db);

                        //Compare decrypted confirmation code against user input 
                        if (returnDBConfirmationCode != null && returnDBConfirmationCode.Count > 0)
                        {
                            foreach (var index in returnDBConfirmationCode)
                            {
                                if (index.ConfirmationCode.Trim() == confirmationCode.Trim())
                                    returnVal = true;
                                else
                                {
                                    Utility.getText = "Confirmation Codes do not match!";
                                    Utility.errorFlag = false;
                                }
                            }
                        }
                        else
                        {
                            Utility.getText = "Something went wrong with the \n confirmation code decryption!";
                            Utility.errorFlag = false;
                        }
                    }
                    else
                    {
                        Utility.errorFlag = false;
                        Utility.getText = "Security question answered incorrectly!";
                    }
                }
                else
                {
                    Utility.errorFlag = false;
                    Utility.getText = "The user does not exist!";
                }
            }
            return returnVal;
        }

        //For every forgot password reset, there will be an encrypted entry in the ConfirmationCodes in the db
        //Iterate through list of encrypted confirmation code binary strings, decrypt each then 
        //Check deciphered plain text against user input
        private List<ConfirmationCodesEntity> decipheredListOfConfirmationCodes(PMS_DBEntities db)
        {
            List<ConfirmationCode> listOfDBConfirmationCodes = db.ConfirmationCodes.ToList();
            List<ConfirmationCodesEntity> decryptedData = new List<ConfirmationCodesEntity>();

            foreach (var index in listOfDBConfirmationCodes)
            {
                byte[] encryptedDBData = index.ConfirmationCode1;

                //Decrypt confirmation code stored in DB 
                byte[] decryptedDBData = cryptoObj.decrypt(encryptedDBData, Utility.confirmationCodePrivateKey);
                string strResult = Encoding.UTF8.GetString(decryptedDBData);

                ConfirmationCodesEntity confirmationCodesObj = new ConfirmationCodesEntity();
                confirmationCodesObj.ConfirmationCode = strResult;
                decryptedData.Add(confirmationCodesObj);
            }

            return decryptedData;
        }

        private List<UserAccountEntity> decipheredListOfDBUsers(PMS_DBEntities db)
        {
            byte[] decryptedDBData = new byte[] { };
            List<UserData> listOfDBUsers = db.UserDatas.ToList();
            List<UserAccountEntity> decryptedData = new List<UserAccountEntity>();

            foreach (UserData index in listOfDBUsers)
            {
                byte[] encryptedDBData = index.UserRSAEncryptedData;
                Utility.encryptedByteArray = encryptedDBData;
                Utility.userDataID = index.Id;

                if (Utility.resetPasswordFlag == true)
                    decryptedDBData = cryptoObj.decrypt(encryptedDBData, Utility.mainPMSUpdatePrivateKey);
                else
                    decryptedDBData = cryptoObj.decrypt(encryptedDBData, Utility.privateKey);

                string strResult = Utility.stringManipulation(decryptedDBData);
                string[] stringArr = strResult.Split(new string[] { "  " },
                                  StringSplitOptions.None);
                string[] cleanStrArray = stringArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                UserAccountEntity userAccObj = new UserAccountEntity();
                userAccObj.password = cleanStrArray[2].TrimStart();
                userAccObj.username = cleanStrArray[0];
                userAccObj.email = cleanStrArray[1];
                userAccObj.passwordReminder = cleanStrArray[3];

                decryptedData.Add(userAccObj);

            }

            return decryptedData;
        }

        public void insertConfirmationCode(int confirmationCode)
        {
            //byte[] intBytes = BitConverter.GetBytes(confirmationCode);
            byte[] intBytes = Encoding.UTF8.GetBytes(Convert.ToString(confirmationCode));

            cryptoObj.createKeys(Utility.confirmationCodePrivateKey, Utility.confirmationCodePublicKey);
            byte[] encryptedData = cryptoObj.encrypt(intBytes, Utility.confirmationCodePublicKey);

            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddConfirmationCode", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = sqlConnection;
                cmd.Connection.Open();

                //Using SQL parameters to protect against SQL injection from attackers
                SqlParameter paraConfirmationCode = new SqlParameter();
                paraConfirmationCode.ParameterName = "@confirmationCode";
                paraConfirmationCode.Value = encryptedData;
                paraConfirmationCode.DbType = DbType.Binary;
                cmd.Parameters.Add(paraConfirmationCode);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public byte[] getConfirmationCode()
        {
            byte[] finalResult = new byte[] { };
            using (var db = new PMS_DBEntities())
            {
                //The last Reset Password Request is stored within the last record in the confirmationCode table
                var result = db.ConfirmationCodes.Last();
                finalResult = result.ConfirmationCode1;
            }
            return finalResult;
        }

        public static T[] Empty<T>()
        {
            return EmptyArray<T>.Value;
        }


        public void login(string[] array)
        {
            using (var db = new PMS_DBEntities())
            {
                string usernameInput = string.Empty;
                string passwordInput = string.Empty;
                int counter = 0;

                if (array != null && array.Count() > 0)
                {
                    usernameInput = array[0];
                    passwordInput = array[1];
                }

                List<UserAccountEntity> dbListOfUsers = decipheredListOfDBUsers(db);
                if (dbListOfUsers != null && dbListOfUsers.Count > 0)
                {
                    foreach (var index in dbListOfUsers)
                    {
                        counter++;
                        if (index.username == usernameInput.Trim()
                            && index.password == passwordInput)
                        {
                            frmMainPMSVaultForm mainForm = new frmMainPMSVaultForm(new ApplicationAccounts());
                            mainForm.Show();
                        }
                        else if (index.username == usernameInput.Trim()
                            && index.password != passwordInput)
                        {
                            Utility.getText = "Username and/or password does not match!";
                            Utility.errorFlag = false;
                        }
                        else
                        {
                            if (counter == dbListOfUsers.Count)
                            {
                                if (Utility.isUserExists == false)
                                    Utility.getText = "User does not exists!";
                            }
                        }
                    }
                }
                else
                {
                    Utility.getText = "User does not exist.\n Consider registering new account!";
                    Utility.errorFlag = false;
                }
            }
        }

        public void registerAccount(string[] array)
        {
            using (var db = new PMS_DBEntities())
            {
                byte[] byteArray = Utility.objectToByteArray(array);

                //Generate Keys
                cryptoObj.createKeys(Utility.privateKey, Utility.publicKey);
                byte[] encrytedData = cryptoObj.encrypt(byteArray, Utility.publicKey);
                bool isExist = false;

                //First check if username does not exist
                UserData dbRec = db.UserDatas.FirstOrDefault(x => x.UserRSAEncryptedData == encrytedData);
                List<UserAccountEntity> listOfDBUsers = decipheredListOfDBUsers(db);
                foreach (var index in listOfDBUsers)
                {
                    if (index.username == array[0].Trim())
                        isExist = true;
                }

                if (dbRec != null || isExist == true)
                    Utility.isUserExists = true;

                if (isExist == false)
                    insertNewUser(encrytedData);
                else
                    Utility.getText = "User already exists!";
            }
        }


        public void insertNewUser(byte[] encrytedDataParams)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddUserData", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = sqlConnection;
                    cmd.Connection.Open();

                    SqlParameter paraUserRSAEncryptedData = new SqlParameter();
                    paraUserRSAEncryptedData.ParameterName = "@UserRSAEncryptedData";
                    paraUserRSAEncryptedData.Value = encrytedDataParams;
                    paraUserRSAEncryptedData.DbType = DbType.Binary;
                    cmd.Parameters.Add(paraUserRSAEncryptedData);

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    Utility.getText = "User added successfully!";
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex));
            }
        }

        public void updateUserRecByPassword(byte[] encrytedDataParams, int IdParams)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateUserData", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = sqlConnection;
                    cmd.Connection.Open();

                    SqlParameter paraUserRSAEncryptedData = new SqlParameter();
                    paraUserRSAEncryptedData.ParameterName = "@UserRSAEncryptedData";
                    paraUserRSAEncryptedData.Value = encrytedDataParams;
                    paraUserRSAEncryptedData.DbType = DbType.Binary;
                    cmd.Parameters.Add(paraUserRSAEncryptedData);

                    SqlParameter paraUserDataID = new SqlParameter();
                    paraUserDataID.ParameterName = "@Id";
                    paraUserDataID.Value = IdParams;
                    paraUserDataID.DbType = DbType.Int32;
                    cmd.Parameters.Add(paraUserDataID);

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex));
            }
        }

        public void updatePassword(string[] array)
        {
            byte[] byteArray = Utility.objectToByteArray(array);

            cryptoObj.createKeys(Utility.mainPMSUpdatePrivateKey, Utility.mainPMSUpdatePublicKey);
            byte[] encrytedData = cryptoObj.encrypt(byteArray, Utility.mainPMSUpdatePublicKey);

            if (encrytedData != null && encrytedData.Count() > 0)
            {
                updateUserRecByPassword(encrytedData, Utility.userDataID);
                Utility.resetPasswordFlag = true;
            }
        }
    }

    internal static class EmptyArray<T>
    {
        public static readonly T[] Value = new T[0];
    }
}
