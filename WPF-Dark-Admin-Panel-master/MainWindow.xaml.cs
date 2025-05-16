using CamadaDados.Venda;
using CamadaNegocios.Enum;
using CamadaNegocios.Venda;
using Dark_Admin_Panel.UserControls;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Identity.Client;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Reflection.Emit;

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
        public SeriesCollection SeriesCollection { get; set; }
        public List<Axis> LabelsAxis { get; set; }
        public List<Axis> YFormatter { get; set; }

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
            AplicarFiltroTopMarcas();
            construirGrafico();
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

        private void construirGrafico()
        {
            this.Vendas = CamadaNegocios.Venda.Venda.ObterListaVendas();

            AxesCollection axesY = new AxesCollection();
            Axis axisY = new Axis();

            axisY.Title = "ABC";
            axisY.MinValue = 0;
            try
            {
                axisY.MaxValue = (double)this.Vendas.ObterMaximo(this.Data, this.Ano) * 1.1;
            }
            catch (Exception ex)
            {
                axisY.MaxValue = 0;
            }
            try
            {
                axisY.Separator.Step = (double)this.Vendas.ObterStepGrafico(this.Data, this.Ano, 5);
                axesY.Add(axisY);
            }
            catch (Exception)
            {

                axisY.Separator.Step = 0;
            }
        
            grafico.AxisY = axesY;


            AxesCollection axesX = new AxesCollection();
            Axis axisX = new Axis();
            axisX.Title = "XYZ";
            axisX.Labels = this.Vendas.ObterValoresDatas(this.Data, this.Ano);
            grafico.AxisX = axesX;

            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "Vendassss";
            ChartValues<int> valuesOfChart = new ChartValues<int>();

            int i = 0;
            foreach (CamadaNegocios.Venda.Venda venda in this.Vendas)
            {
                
                if (i < 100)
                {
                    valuesOfChart.Add((int)venda.Preco);
                    i++;
                }
                else
                {
                    break;
                }

            }

            MessageBox.Show(axisY.Separator.Step.ToString());
            



            lineSeries.Values = valuesOfChart;
            
            grafico.Series.Add(lineSeries);


            //DataContext = this;


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
                string totalFaturacaoFormatado = totalFaturacao.Value.ToString("#,0.00", CultureInfo.InvariantCulture);
                this.TotalFaturacaoInfoCard.Number = totalFaturacaoFormatado + " €";
            }
        }

        private void AplicarFiltroTopMarcas()
        {
            foreach (var element in this.Vendas.ObterMarcasVendas(this.Data, this.Ano))
            {
                Item item = new Item();
                item.Title = element.Key; 
                item.Desc = element.Value.HasValue
                    ? element.Value.Value.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(',', '.') + " €"
                    : "NA";
                
                this.TopMarcasStackPanel.Children.Add(item);

  
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