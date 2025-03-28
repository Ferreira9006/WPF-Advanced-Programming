using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CamadaNegocios.Enum;

namespace Dark_Admin_Panel.UserControls
{
    /// <summary>
    /// Interaction logic for FiltroPorDataUserControl.xaml
    /// </summary>
    public partial class FiltroPorDataUserControl : UserControl
    {
        public static RoutedEvent BotaoSelecionadoEvento = 
            EventManager.RegisterRoutedEvent("BotaoSelecionado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FiltroPorDataUserControl));
        
        public event RoutedEventHandler BotaoSelecionado
        {
            add { AddHandler(BotaoSelecionadoEvento, value); }
            remove { RemoveHandler(BotaoSelecionadoEvento, value); }
        }

        public FiltroPorDataUserControl()
        {
            InitializeComponent();
        }

        private FiltroPorDataEnum tipoFiltroPorData;

        public FiltroPorDataEnum TipoFiltroPorData
        {
            get { return tipoFiltroPorData; }
            set 
            {
                tipoFiltroPorData = value;
                this.Texto = tipoFiltroPorData.ObterDescricao();
            }
        }

        private bool selecionado;

        public bool Selecionado
        {
            get { return selecionado; }
            set { 
                selecionado = value;
                if (!selecionado)
                {
                    this.dataButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                }
                else
                {
                    this.dataButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                    this.dataButton.FontWeight = FontWeights.Bold;
                }


            }
        }


        private string texto;

        public string Texto
        {
            get { return texto; }
            set 
            {
                texto = value;
                this.dataButton.Content = value;
            }
        }

        private void dataButton_Click(object sender, RoutedEventArgs e)
        {
            this.Selecionado = true;
            RaiseEvent(new RoutedEventArgs(BotaoSelecionadoEvento));
        }
    }
}
