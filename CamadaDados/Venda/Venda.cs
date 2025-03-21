using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


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

        public static DataTable Listar( DateTime dataInicio, DateTime dataFim, out string errorMessage)
        {
            //instaciar objeto do tipo dataTable
            DataTable dataTable = null;
            try
            {   //string que guarda caminho para sql, localizada nas propriedadades
                string connectionString = Properties.Settings.Default.ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "ClienteListar";

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception)
            {


            }

            return dataTable;
        }

     
        #endregion



    }
}
