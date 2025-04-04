using CamadaNegocios.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios.Eventos
{
    public class AnoEventArgs:EventArgs
    {

        #region Construtores

        public AnoEventArgs(int ano)
        {
            this.Ano = ano;
        }
        #endregion

        #region Propriedades
        private int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }


        #endregion
    }
}
