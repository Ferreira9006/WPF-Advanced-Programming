using CamadaNegocios.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios.Eventos
{
    public class DataEventArgs:EventArgs
    {
        #region Construtores

        public DataEventArgs(DatasEnum data)
        {
            this.Data = data;
        }
        #endregion

        #region Propriedades
        private DatasEnum data;

        public DatasEnum Data
        {
            get { return data; }
            set { data = value; }
        }


        #endregion
    }
}
