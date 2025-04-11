using CamadaDados.Venda;
using CamadaNegocios.Enum;
using CamadaNegocios.Venda;
using Dark_Admin_Panel.UserControls;
using Microsoft.Identity.Client;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace Dark_Admin_Panel
{
    public partial class MainWindow : Window
    {
        #region Construtores

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        VendaCollection Vendas { get; set; }

        private DatasEnum datas;

        public DatasEnum Data
        {
            get { return datas; }
            set { datas = value;

                

            }
        }

        private int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }




        #endregion

        #region Metodos

        private void AplicarFiltro()
        {
            AplicarFiltroTopVendedor();
            AplicarFiltroTotalCarrosVendidos();
            AplicarFiltroTotalFaturacao();
        }

        private void AplicarFiltroTopVendedor()
        {
            var topVendedor = this.Vendas.ObterTopVendedor(this.Data, this.Ano);

            if (topVendedor == null)
            {
                this.TopVendedorInfoCard.Number = "NA";
            }
            else
            {
                this.TopVendedorInfoCard.Number = topVendedor.ToString();
            }
        }

        private void AplicarFiltroTotalCarrosVendidos()
        {
            int totalCarrosVendidos = this.Vendas.ObterTotalAutomoveisVendidos(this.Data, this.Ano);

            if (totalCarrosVendidos == 0)
            {
                this.TotalCarrosVendidosInfoCard.Number = "NA";
            }
            else
            {
                this.TotalCarrosVendidosInfoCard.Number = totalCarrosVendidos.ToString();
            }
        }

        private void AplicarFiltroTotalFaturacao()
        {
            float? totalFaturacao = this.Vendas.ObterTotalFaturacao(this.Data, this.Ano);

            if (totalFaturacao == null)
            {
                this.TotalFaturacaoInfoCard.Number = "NA";
            }
            else
            {
                string totalFaturacaoFormatado = totalFaturacao.Value.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(',', '.');
                this.TotalFaturacaoInfoCard.Number = totalFaturacaoFormatado + " €";
            }
        }

        #endregion

        #region Eventos

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Vendas = CamadaNegocios.Venda.Venda.ObterListaVendas();


            this.AplicarFiltro();
        }

       

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void StackPanelFiltrosUserControl_DataSelecionadoEvento(object sender, CamadaNegocios.Eventos.DataEventArgs e)
        {
            this.Data = e.Data;
            this.Ano = 0;
            this.AplicarFiltro();
        }

        private void StackPanelFiltrosUserControl_AnoSelecionadoEvento(object sender, CamadaNegocios.Eventos.AnoEventArgs e)
        {
        

            this.Ano = e.Ano;
            this.Data = DatasEnum.Todos;
            this.AplicarFiltro();
        }

        #endregion

    }
}