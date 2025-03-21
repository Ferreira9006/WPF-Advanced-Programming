using CamadaNegocios.Venda;
using System.Windows;
using System.Windows.Input;

namespace Dark_Admin_Panel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VendaCollection vendas = CamadaNegocios.Venda.Venda.ObterListaVendas();

          

            this.TopVendedorInfoCard.Number = vendas.ObterTopVendedor().ToString();

        }
    }
}