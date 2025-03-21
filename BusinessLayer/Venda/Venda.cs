using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Venda
{
    public class Venda
    {
        #region Construtores

        public Venda()
        {
            this.vendaId = null;
            this.data = DateTime.MinValue;
            this.preco = null;
            this.vendedorId = null;
            this.marcaId = null;
        }
        public Venda(int? vendaId, DateTime data, float? preco, int? vendedorId, int? marcaId)
        {
            this.vendaId = vendaId;
            this.data = data;
            this.preco = preco;
            this.vendedorId = vendedorId;
            this.marcaId = marcaId;
        }

        #endregion

        #region Propriedades

        private int? vendaId;

        public int? VendaId
        {
            get { return vendaId; }
            set { vendaId = value; }
        }

        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private float? preco;

        public float? Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        private int? vendedorId;

        public int? VendedorId
        {
            get { return vendedorId; }
            set { vendedorId = value; }
        }

        private int? marcaId;

        public int? MarcaId
        {
            get { return marcaId; }
            set { marcaId = value; }
        }

        #endregion

        #region Metodos
       
        public static DataTable Listar(out string erro)
        {
            DataTable dataTable = DataLayer.Venda.Venda.Listar(out erro);
            return dataTable;
        }

        public static VendaCollection ObterListaVendas()
        {
            string erro = string.Empty;

            DataTable dataTable = Venda.Listar(out erro);

            VendaCollection vendas = new VendaCollection(dataTable);

            return vendas;
        }
        #endregion
    }
}
