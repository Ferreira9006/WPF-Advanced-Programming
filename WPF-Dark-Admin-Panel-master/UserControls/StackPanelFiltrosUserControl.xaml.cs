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
using CamadaNegocios.Eventos;

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

            for (int i = 2020; i <= DateTime.Now.Year; i++)
            {
                anoComboBox.Items.Add(i.ToString());
            }
    

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
                    

                    filtroPorDataUserControl.Selecionado = true;
                    this.TipoDataSelecionada = filtroPorDataUserControl.Tipo;

                    OnDataSelecionado(new DataEventArgs(this.TipoDataSelecionada));
                }
                else
                {
                    filtroPorDataUserControl.Selecionado = false;
                }
            }
        }


        
        

        public event EventHandler<DataEventArgs> DataSelecionadoEvento;

        public void OnDataSelecionado(DataEventArgs e)
        {
            DataSelecionadoEvento?.Invoke(this, e);

            if (TipoDataSelecionada == DatasEnum.Todos)
            {
                anoComboBox.SelectedValue = String.Empty;
            } else
            {
                anoComboBox.SelectedItem = DateTime.Today.Year.ToString();
            }

        }


         public event EventHandler<AnoEventArgs> AnoSelecionadoEvento;

        public void OnAnoSelecionado(AnoEventArgs e)
        {
            AnoSelecionadoEvento?.Invoke(this, e);

            foreach (FiltroPorDataUserControl filtroPorDataUserControl in this.FiltrosDatas.Children)
            {
                filtroPorDataUserControl.Selecionado = false;
            }
        }





        #endregion

        private void anoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (anoComboBox.SelectedItem != null)
            {
                int ano = Convert.ToInt32(anoComboBox.SelectedItem);

                OnAnoSelecionado(new AnoEventArgs(ano));

            }

        }
    }
}
