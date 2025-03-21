using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios.Venda
{
    public class Venda
    {
        #region Construtores

        public Venda()
        {
            this.vendaId = null;
            this.dataVenda = DateTime.MinValue;
            this.preco = null;
            this.nomeVendedor = string.Empty;
            this.descricaoMarca = string.Empty;
        }
        public Venda(int? vendaId, DateTime dataVenda, float? preco, string nomeVendedor, string descricaoMarca)
        {
            this.vendaId = vendaId;
            this.dataVenda = dataVenda;
            this.preco = preco;
            this.nomeVendedor = nomeVendedor;
            this.descricaoMarca = descricaoMarca;
        }

        #endregion

        #region Propriedades

        private int? vendaId;

        public int? VendaId
        {
            get { return vendaId; }
            set { vendaId = value; }
        }

        private DateTime dataVenda;

        public DateTime DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }

        private float? preco;

        public float? Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        private string nomeVendedor;

        public string NomeVendedor
        {
            get { return nomeVendedor; }
            set { nomeVendedor = value; }
        }

        private string descricaoMarca;

        public string DescricaoMarca
        {
            get { return descricaoMarca; }
            set { descricaoMarca = value; }
        }

        #endregion

        #region Metodos

        public static DataTable Listar(out string erro)
        {
            erro = string.Empty;
            DataTable dataTable = CamadaDados.Venda.Venda.ObterLista();
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
