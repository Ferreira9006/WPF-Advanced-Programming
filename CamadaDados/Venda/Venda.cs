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
        
        public static DataTable ObterLista()
        {
            DataTable dataTable = null;
            try
            {
                string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramacaoAvancada;Data Source=Pedro\\SQLEXPRESS;Encrypt=False";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "ListarVendas";

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return dataTable;
        }
        #endregion



    }
}
