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
using System.Linq;
using System.Windows.Media.Animation;

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
            set
            {
                datas = value;
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

        private void limparGrafico()
        {
            grafico.Series.Clear();
            grafico.AxisX.Clear();
            grafico.AxisY.Clear();
        }

        private int obterStepX(DatasEnum datas)
        {
            switch (datas)
            {
                case DatasEnum.Semana:
                    return 1;
                case DatasEnum.Mes:
                    return 3;
                case DatasEnum.Hoje:
                    return 1;
                case DatasEnum.Todos:
                    return 20;
                default:
                    return 1; // Default step if not specified
            }
        }

        private void construirGrafico()
        {
            limparGrafico();

            this.Vendas = CamadaNegocios.Venda.Venda.ObterListaVendas();

            AxesCollection axesY = new AxesCollection();
            Axis axisY = new Axis();

            axisY.Title = "Euros €";
            axisY.MinValue = 0;
            axesY.Add(axisY);
            grafico.AxisY = axesY;


            AxesCollection axesX = new AxesCollection();
            Axis axisX = new Axis();
            axisX.Title = "Dias";
            axisX.Labels = [];

            (DateTime dataInicial, DateTime dataFinal) = this.Vendas.obterDatas(this.Data, this.Ano);


            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "Euros";
            ChartValues<int> valuesOfChart = new ChartValues<int>();

            Dictionary<DateTime, float> listaAgrupada = new Dictionary<DateTime, float>();

           
            foreach (CamadaNegocios.Venda.Venda venda in this.Vendas)
            {
                DateTime date = venda.DataVenda.Date;
                float? valor = venda.Preco;

                if (valor.HasValue && date >= dataInicial && date <= dataFinal)
                {
                    if (!listaAgrupada.ContainsKey(date))
                    {
                        listaAgrupada.Add(date, valor.Value);
                        axisX.Labels.Add(venda.DataVenda.ToString("dd/MM/yy"));
                    }
                    else
                    {
                        listaAgrupada[date] += valor.Value;
                    }
                }
            }

            axesX.Add(axisX);
            grafico.AxisX = axesX;

            axisX.Separator.Step = obterStepX(datas);

            //axisY.Separator.Step = axisY.Separator.Step * 2;
            axisY.MaxValue = listaAgrupada.Values.Max() * 1.05;

            foreach (KeyValuePair<DateTime, float> item in listaAgrupada.OrderBy(k => k.Key))
            {
                valuesOfChart.Add((int)item.Value);
            }


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
            this.TopMarcasStackPanel.Children.Clear();

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

        private void StackPanelFiltrosUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}