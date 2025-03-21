using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios.Venda
{
    public class VendaCollection : ObservableCollection<Venda>
    {
        #region Construtores

        public VendaCollection()
        {

        }
        public VendaCollection(DataTable dataTable) : this()
        {
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Venda venda = new Venda();
                    venda.VendaId = dataRow.Field<int>("VendaId");
                    venda.DataVenda = dataRow.Field<DateTime>("Data");
                    venda.Preco = dataRow.Field<float>("Preco");
                    venda.NomeVendedor = dataRow.Field<string>("NomeVendedor");
                    venda.DescricaoMarca = dataRow.Field<string>("DescricaoMarca");

                    this.Add(venda);
                }
            }
        }
        #endregion
    }
}
