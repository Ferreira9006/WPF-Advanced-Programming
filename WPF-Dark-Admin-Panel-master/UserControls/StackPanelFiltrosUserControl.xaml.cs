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
    /// Interaction logic for StackPanelFiltrosUserControl.xaml
    /// </summary>
    public partial class StackPanelFiltrosUserControl : UserControl
    {
        #region Construtores

        public StackPanelFiltrosUserControl()
        {
            InitializeComponent();
            this.InicializarFiltros();
        }

        #endregion

        #region Proprieades

        private DatasEnum tipoDataSelecionada;

        public DatasEnum TipoDataSelecionada
        {
            get { return tipoDataSelecionada; }
            set
            {
                tipoDataSelecionada = value;
            }
        }

        #endregion

        #region Métodos

        private void InicializarFiltros()
        {
            this.TipoDataSelecionada = DatasEnum.Todos;

            FiltroPorAnoUserControl anosUserControl = new FiltroPorAnoUserControl();

            for (int i = 2020; i <= DateTime.Now.Year; i++)
            {
                anosUserControl.Anos.Items.Add(i.ToString());
            }

            this.FiltrosAnos.Children.Add(anosUserControl);

            foreach (CamadaNegocios.Enum.DatasEnum datasEnum in Enum.GetValues(typeof(CamadaNegocios.Enum.DatasEnum)))
            {
                FiltroPorDataUserControl filtroPorDataUserControl = new FiltroPorDataUserControl();
                filtroPorDataUserControl.Tipo = datasEnum;

                filtroPorDataUserControl.Selecionado = (datasEnum == this.TipoDataSelecionada);
                filtroPorDataUserControl.BotaoSelecionadoEvento += selecionou;

                this.FiltrosDatas.Children.Add(filtroPorDataUserControl);
            }
        }

        #endregion

        #region Eventos

        private void selecionou (object sender, EventArgs e)
        {
            foreach (FiltroPorDataUserControl filtroPorDataUserControl in this.FiltrosDatas.Children)
            {
                if (filtroPorDataUserControl.Tipo == ((FiltroPorDataUserControl)sender).Tipo)
                {
                    MessageBox.Show("Selecionou o filtro: " + filtroPorDataUserControl.Tipo); // Debug

                    filtroPorDataUserControl.Selecionado = true;
                    this.TipoDataSelecionada = filtroPorDataUserControl.Tipo;
                }
                else
                {
                    filtroPorDataUserControl.Selecionado = false;
                }
            }
        }
        
        #endregion
    }
}
