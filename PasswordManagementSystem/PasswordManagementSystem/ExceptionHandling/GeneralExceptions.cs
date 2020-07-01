using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.ExceptionHandling
{
    public class GeneralExceptions
    {
        public void LogExceptions(string actionPerformed, string exceptionCaught, string exceptionMessage, DateTime? dateRecorded)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddException", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = sqlConnection;
                cmd.Connection.Open();

                SqlParameter paraActionPerformed = new SqlParameter();
                paraActionPerformed.ParameterName = "@actionPerformed";
                paraActionPerformed.Value = actionPerformed;
                cmd.Parameters.Add(paraActionPerformed);

                SqlParameter paraExceptionCaught = new SqlParameter();
                paraExceptionCaught.ParameterName = "@exceptionCaught";
                paraExceptionCaught.Value = exceptionCaught;
                cmd.Parameters.Add(paraExceptionCaught);

                SqlParameter paraExceptionMessage = new SqlParameter();
                paraExceptionMessage.ParameterName = "@exceptionMessage";
                paraExceptionMessage.Value = exceptionMessage;
                cmd.Parameters.Add(paraExceptionMessage);

                SqlParameter paraDateRecorded = new SqlParameter();
                paraDateRecorded.ParameterName = "@dateRecorded";
                paraDateRecorded.Value = dateRecorded;
                cmd.Parameters.Add(paraDateRecorded);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}
