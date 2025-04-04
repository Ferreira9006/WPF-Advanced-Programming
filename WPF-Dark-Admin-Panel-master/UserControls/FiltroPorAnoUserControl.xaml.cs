using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace Dark_Admin_Panel.UserControls
{
    /// <summary>
    /// Interaction logic for FiltroPorAnoUserControl.xaml
    /// </summary>
    public partial class FiltroPorAnoUserControl : UserControl
    {
        public FiltroPorAnoUserControl()
        {
            InitializeComponent();
        }
        #region Propriedades


        private int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        private bool selecionado;

        public bool Selecionado
        {
            get { return selecionado; }
            set { selecionado = value; }
        }
        #endregion


        #region Metodos

        #endregion
        #region Eventos


        public event EventHandler<EventArgs> AnoSelecionadoEvento;

        

        #endregion
    }
}
