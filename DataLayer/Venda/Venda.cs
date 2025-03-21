using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDGlobal;

namespace DataLayer.Venda
{
    public class Venda
    {
        #region Metodos


        // falta adicionar o parametro de data inicial e final
        public static DataTable Listar(out string erro)
        {
            DataTable dataTable = GlobalDB.RetrieveList("ListarVendas", Properties.Settings.Default.ConnectionString, out erro);

            return dataTable;
        }

       
        #endregion
    }
}
