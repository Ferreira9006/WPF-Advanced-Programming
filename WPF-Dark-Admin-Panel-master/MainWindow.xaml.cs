using CamadaDados.Venda;
using CamadaNegocios.Enum;
using CamadaNegocios.Venda;
using Dark_Admin_Panel.UserControls;
using Microsoft.Identity.Client;
using System;
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

        #region Eventos

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Vendas = CamadaNegocios.Venda.Venda.ObterListaVendas();


            this.AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (this.Vendas.ObterTopVendedor(this.Data, this.Ano) == null)
            {
                this.TopVendedorInfoCard.Number = "NA";
            } else
            {
                this.TopVendedorInfoCard.Number = this.Vendas.ObterTopVendedor(this.Data, this.Ano).ToString();
            }

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

        #endregion

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
    }
}