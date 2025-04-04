using CamadaNegocios.Enum;
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
                    venda.DataVenda = dataRow.Field<DateTime>("DataVenda");
                    venda.Preco = dataRow.Field<float>("Preco");
                    venda.NomeVendedor = dataRow.Field<string>("NomeVendedor");
                    venda.DescricaoMarca = dataRow.Field<string>("DescricaoMarca");

                    this.Add(venda);
                }
            }
        }
        #endregion

        #region Metodos

        public string ObterTopVendedor(DatasEnum datasEnum, int ano)
        {
            (DateTime dataInicial, DateTime dataFinal) = this.obterDatas(datasEnum, ano);
            var topVendedor = this
                            .Where(e => e.DataVenda >= dataInicial && e.DataVenda <= dataFinal)
                            .GroupBy(e => e.NomeVendedor)
                            .Select(g => new
                            {
                                NomeVendedor = g.Key,
                                TotalVendas = g.Sum(x => x.Preco)
                            })
                            .OrderByDescending(g => g.TotalVendas)
                            .FirstOrDefault()?.NomeVendedor;

            return topVendedor;
        }

        private (DateTime, DateTime) obterDatas(DatasEnum tipoData, int ano)
        {
            DateTime dataInicial = DateTime.MinValue;
            DateTime dataFinal = DateTime.MinValue;


            if(ano > 0)
            {
                dataInicial = new DateTime(ano, 1, 1);
                dataFinal = new DateTime(ano, 12, 31);
            }
            else
            {
                if (tipoData == DatasEnum.Mes)
                {
                    dataInicial = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    dataFinal = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
                    dataFinal = dataFinal.AddDays(-1);
                }
                else if (tipoData == DatasEnum.Semana)
                {
                    dataInicial = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    dataFinal = dataInicial.AddDays(6);
                }
                else if (tipoData == DatasEnum.Hoje)
                {
                    dataInicial = DateTime.Today;
                    dataFinal = DateTime.Today;
                }
                else if (tipoData == DatasEnum.Todos)
                {
                    dataInicial = DateTime.MinValue;
                    dataFinal = DateTime.MaxValue;
                }

            }
            

            return (dataInicial, dataFinal);
        }

        #endregion
    }
}
