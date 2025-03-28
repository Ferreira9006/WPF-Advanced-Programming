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
        public StackPanelFiltrosUserControl()
        {
            InitializeComponent();
            this.CriarFiltros();
        }


        private FiltroPorDataEnum tipoFiltroPorDataSelecionada;

        public FiltroPorDataEnum TipoFiltroPorDataSelecionada
        {
            get { return tipoFiltroPorDataSelecionada; }
            set
            {
                tipoFiltroPorDataSelecionada = value;
            }
        }

        private void CriarFiltros()
        {
            this.TipoFiltroPorDataSelecionada = FiltroPorDataEnum.Todos;
            foreach (CamadaNegocios.Enum.FiltroPorDataEnum filtroPorDataEnum in Enum.GetValues(typeof(CamadaNegocios.Enum.FiltroPorDataEnum)))
            {
                FiltroPorDataUserControl filtroPorDataUserControl = new FiltroPorDataUserControl();
                filtroPorDataUserControl.TipoFiltroPorData = filtroPorDataEnum;
                //filtroPorDataUserControl.Texto = filtroPorDataEnum.ObterDescricao();

                filtroPorDataUserControl.Selecionado = (filtroPorDataEnum == this.TipoFiltroPorDataSelecionada);
                filtroPorDataUserControl.BotaoSelecionado += selecionou;

                this.Filtros.Children.Add(filtroPorDataUserControl);
            }
        }

        private void selecionou (object sender, RoutedEventArgs e)
        {
            foreach (FiltroPorDataUserControl filtroPorDataUserControl in this.Filtros.Children)
            {
                if (filtroPorDataUserControl.TipoFiltroPorData == ((FiltroPorDataUserControl)sender).TipoFiltroPorData)
                {
                    filtroPorDataUserControl.Selecionado = true;
                    this.TipoFiltroPorDataSelecionada = filtroPorDataUserControl.TipoFiltroPorData;
                }
                else
                {
                    filtroPorDataUserControl.Selecionado = false;
                }
            }

            //MessageBox.Show("selecionou");
        }
    }
}
