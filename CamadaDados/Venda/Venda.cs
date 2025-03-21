using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Venda
{
    public class Venda
    {
        #region Methods

        public static SqlConnection OpenDatabase(string connectionString)
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            return dbConnection;
        }

        public static DataTable RetrieveList(string storedProcedureName, string connectionString, out string errorMessage)
        {
            DataTable dataTable = null;
            errorMessage = string.Empty;
            try
            {
                SqlConnection dbConnection = GlobalDB.OpenDatabase(connectionString);

                SqlCommand dbCommand = new SqlCommand(storedProcedureName, dbConnection);
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                dbCommand.Dispose();
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return dataTable;
        }


        #endregion
    }
}
