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
                string connectionString = @";Data Source=PEDRO\SQLEXPRESS
;Initial Catalog=ProgramacaoAvancada;Integrated Security=True;TrustServerCertificate=True";
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
