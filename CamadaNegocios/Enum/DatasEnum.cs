using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios.Enum
{
    public enum DatasEnum
    {
        Todos,
        Hoje,
        Semana,
        Mes
        
    }

    public static class DatasEnumExtensions
    {
        public static string ObterDescricao(this DatasEnum datasEnum)
        {
            switch (datasEnum)
            {
                case DatasEnum.Todos:
                    return "Todos";
                case DatasEnum.Hoje:
                    return "Hoje";
                case DatasEnum.Semana:
                    return "Semana";
                case DatasEnum.Mes:
                    return "Mês";
               
                default:
                    return string.Empty;
            }
        }


        public static DateTime ObterData()
        {

            return DateTime.Now;
        }
    }
}
