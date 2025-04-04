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
        #region Construtores

        public event EventHandler<EventArgs> BotaoSelecionadoEvento;

        public FiltroPorDataUserControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Propriedades

        private DatasEnum tipo;

        public DatasEnum Tipo
        {
            get { return tipo; }
            set 
            {
                tipo = value;
                this.Texto = tipo.ObterDescricao();
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
                    this.dataButton.FontWeight = FontWeights.Normal;
                    return;                    
                }

                this.dataButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                this.dataButton.FontWeight = FontWeights.Bold;
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

        #endregion

        #region Eventos

        public void OnBotaoSelecionado(EventArgs e)
        {
            BotaoSelecionadoEvento?.Invoke(this, e);
        }

      

        #endregion

        private void dataButton_Click(object sender, EventArgs e)
        {
            this.Selecionado = true;
             OnBotaoSelecionado(EventArgs.Empty);
        }
    }
}
